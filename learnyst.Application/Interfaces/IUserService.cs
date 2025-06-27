using learnyst.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetByIdAsync(int id);
        public Task<UserDto> GetByEmailAsync(string email);
        public Task<List<UserDto>> GetAllAsync();
        Task AddAsync(UserDto userDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(UserDto userDto);
    }
}
