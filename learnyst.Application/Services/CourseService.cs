using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<course> _courseRepository;

        public CourseService(IGenericRepository<course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var user = await _courseRepository.GetByIdAsync(id);
            if (user == null) return new CourseDto();
            return new CourseDto
            {
                id = user.id, 
            }; 
        }

        public async Task AddAsync(CourseDto courseDto)
        {
            await _courseRepository.AddAsync(new course() { id = courseDto.id });
        }

        public async Task DeleteAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.ListAllAsync();
            return courses.Select(user => new CourseDto
            {
                id = user.id
            }).ToList();
        }

        public async Task UpdateAsync(CourseDto courseDto)
        {
            await _courseRepository.UpdateAsync(new course
            {
                id = courseDto.id
            });
        }
    }
}
