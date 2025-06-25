using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers.User
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetUserById")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id) =>
            Ok(await _userService.GetByIdAsync(id));

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() =>
            Ok(await _userService.GetAllAsync());

        [Route("AddUsers")]
        [HttpPost]
        public async Task<IActionResult> AddUsers(UserDto userDto)
        {
            await _userService.AddAsync(userDto);
            return Ok(userDto);
        }

        [Route("UpdateUsers")]
        [HttpPut]
        public async Task<IActionResult> UpdateUsers(UserDto userDto)
        {
            await _userService.UpdateAsync(userDto);
            return Ok(userDto);
        }

        [Route("DeleteUsers")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
