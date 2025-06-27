using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers.User
{
    [ApiController]
    [Route("api/[controller]/")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IJwtService jwtService, IConfiguration config)
        {
            _userService = userService;
            _jwtService = jwtService;
            _config = config;
        }

        [Route("get-user-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id) =>
            Ok(await _userService.GetByIdAsync(id));

        [Route("get-all-users")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() =>
            Ok(await _userService.GetAllAsync());

        [Route("update-user")]
        [HttpPut]
        public async Task<IActionResult> UpdateUsers(UserDto userDto)
        {
            await _userService.UpdateAsync(userDto);
            return Ok(userDto);
        }

        [Route("delete-user")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
