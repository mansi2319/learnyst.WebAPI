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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<user> _userRepository;

        public UserService(IGenericRepository<user> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return new UserDto();
            return new UserDto
            {
                id = user.id, 
                signup_date = user.signup_date,
                email = user.email,
                name = user.name,
                role = user.role?.ToString()
            }; 
        }

        public async Task AddAsync(UserDto userDto)
        {
            await _userRepository.AddAsync(new user() { id = userDto.id });
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.ListAllAsync();
            return users.Select(user => new UserDto
            {
                id = user.id,
                name = user.name,
            }).ToList();
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            await _userRepository.UpdateAsync(new user
            {
                id = userDto.id,
                email = userDto.email,
                name = userDto.name,
                role = userDto.role?.ToString()
            });
        }
    }
}
