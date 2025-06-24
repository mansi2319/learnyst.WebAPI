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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return new UserDto();
            return new UserDto
            {
                id = user.id,
                email = user.email,
                name = user.name,
                role = user.role?.ToString(),
                signup_date = user.signup_date
            };
        }

        public async Task AddAsync(UserDto userDto)
        {
            await _unitOfWork.Users.AddAsync(new user
            {
                id = userDto.id,
                name = userDto.name,
                email = userDto.email,
                signup_date = userDto.signup_date,
                role = userDto.role
            });
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.ListAllAsync();
            return users.Select(u => new UserDto
            {
                id = u.id,
                name = u.name
            }).ToList();
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            await _unitOfWork.Users.UpdateAsync(new user
            {
                id = userDto.id,
                name = userDto.name,
                email = userDto.email,
                role = userDto.role
            });
            await _unitOfWork.CompleteAsync();
        }
    }
}
