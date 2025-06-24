using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Route("GetCourseById")]
        [HttpGet]
        public async Task<IActionResult> GetCourseById(int id) =>
            Ok(await _courseService.GetByIdAsync(id));

        [Route("GetAllCourses")]
        [HttpGet]
        public async Task<IActionResult> GetAllCourses() =>
            Ok(await _courseService.GetAllAsync());

        [Route("AddCourse")]
        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseDto courseDto)
        {
            await _courseService.AddAsync(courseDto);
            return Ok(courseDto);
        }

        [Route("UpdateCourse")]
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseDto courseDto)
        {
            await _courseService.UpdateAsync(courseDto);
            return Ok(courseDto);
        }

        [Route("DeleteCourse")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
