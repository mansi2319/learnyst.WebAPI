using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IGenericRepository<Course> _courseRepo;
        public CoursesController(IGenericRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _courseRepo.ListAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            await _courseRepo.AddAsync(course);
            return Ok(course);
        }
    }
}
