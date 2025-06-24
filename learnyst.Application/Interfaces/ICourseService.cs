using learnyst.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Interfaces
{
    public interface ICourseService
    {
        public Task<CourseDto> GetByIdAsync(int id);
        public Task<List<CourseDto>> GetAllAsync();
        Task AddAsync(CourseDto courseDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(CourseDto courseDto);
    }
}
