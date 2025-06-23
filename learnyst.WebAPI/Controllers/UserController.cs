using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<user> _courseRepo;
        public UserController(IGenericRepository<user> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _courseRepo.ListAllAsync());

        [HttpPost]
        public async Task<IActionResult> Users(user course)
        {
            await _courseRepo.AddAsync(course);
            return Ok(course);
        }
    }
}
