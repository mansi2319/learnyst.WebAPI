using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace learnyst.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService; 
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public AuthController(IUserService userService, IJwtService jwtService, IConfiguration config, IEmailService emailService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _config = config;
            _emailService = emailService;
        }

        [Route("user-registration")]
        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserDto userDto)
        {
            await _userService.AddAsync(userDto);
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.GetByIdAsync(dto.userId);
            if (user == null)
                return Unauthorized(new { message = "Invalid user ID" });

            var isValid = _jwtService.VerifyPassword(dto.password, user.password);
            if (!isValid)
                return Unauthorized(new { message = "Incorrect password" });

            var jwtSettings = _config.GetSection("JwtSettings");
            var token = _jwtService.GenerateToken(dto.userId);

            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["expiryminutes"])),
            });

            return Ok(new
            {
                token = token,
                message = "Login successful",
                userId = user.id
            });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _userService.GetByEmailAsync(dto.Email);
            if (user == null)
                return NotFound(new { message = "User not found with this email" });

            var token = _jwtService.GenerateToken((int)user.id, "reset");
            var resetLink = $"{Request.Scheme}://{Request.Host}/api/Auth/reset-password?token={token}";

            string subject = "Reset your password";
            string body = $"Click the link to reset your password: <a href='{resetLink}'>Reset Password</a>";

            await _emailService.SendAsync(dto.Email, subject, body);

            return Ok(new { message = $"Password reset link has been sent to your email. Link is: <a href='{resetLink}'>" });
            }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var userId = _jwtService.ValidateToken(dto.Token, "reset");
            if (userId == null)
                return BadRequest(new { message = "Invalid or expired token. Please request a new password reset." });

            var user = await _userService.GetByIdAsync(userId.Value);
            if (user == null)
                return NotFound(new { message = "User not found. Please ensure you're using the correct reset link." });

            var isValid = _jwtService.VerifyPassword(dto.OldPassword, user.password);
            if (!isValid)
                return Unauthorized(new { message = "Current password is incorrect." });

            user.password = dto.NewPassword;
            await _userService.UpdateAsync(user);

            return Ok(new { message = "Password has been updated successfully." });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return Ok(new { message = "Logged out successfully" });
        }
    }
}
