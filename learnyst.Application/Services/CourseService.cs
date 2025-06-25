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
                updated_at = user.updated_at,
                access_duration = user.access_duration,
                created_at = user.created_at,
                description = user.description,
                instructor_id = user.instructor_id,
                price = user.price,
                status = user.status,
                title = user.title,
                visibility = user.visibility,
            }; 
        }

        public async Task AddAsync(CourseDto courseDto)
        {
            await _courseRepository
                .AddAsync(new course() { 
                     visibility = courseDto.visibility,
                     title = courseDto.title,
                     status = courseDto.status,
                     price = courseDto.price,
                     instructor_id = courseDto.instructor_id,
                     description = courseDto.description,
                     created_at = courseDto.created_at,
                     access_duration = courseDto.access_duration,
                     updated_at = courseDto.updated_at,
                });
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
                id = user.id,
                updated_at = user.updated_at,
                access_duration = user.access_duration,
                created_at = user.created_at,
                description = user.description,
                instructor_id = user.instructor_id,
                price = user.price,
                status = user.status,
                title = user.title,
                visibility = user.visibility
            }).ToList();
        }

        public async Task UpdateAsync(CourseDto courseDto)
        {
            if (courseDto.id == null)
                throw new ArgumentException("Course ID cannot be null for update operation.");

            await _courseRepository.UpdateAsync(new course
            {
                id = (int)courseDto.id,
                visibility = courseDto.visibility,
                instructor_id = courseDto.instructor_id,
                price = courseDto.price,
                title = courseDto.title,
                status = courseDto.status,
                description = courseDto.description,
                updated_at = courseDto.updated_at,
                access_duration = courseDto.access_duration,
                created_at = courseDto.created_at,
                
            });
        }
    }
}
