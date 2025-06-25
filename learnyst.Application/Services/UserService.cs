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
                signup_date = user.signup_date,
                date_of_birth = user.date_of_birth,
                mobile_number = user.mobile_number,
                password = user.password,
                profile_image_url = user.profile_image_url,
                updated_at = user.updated_at,
            };
        }

        public async Task AddAsync(UserDto userDto)
        {
            await _unitOfWork.Users.AddAsync(new user
            {
                name = userDto.name,
                email = userDto.email,
                signup_date = userDto.signup_date,
                role = userDto.role,
                updated_at = userDto.updated_at,
                profile_image_url = userDto.profile_image_url,
                date_of_birth = userDto.date_of_birth,
                password = userDto.password,
                mobile_number = userDto.mobile_number,
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
            return users.Select(user => new UserDto
            {
                id = user.id,
                email = user.email,
                name = user.name,
                role = user.role?.ToString(),
                signup_date = user.signup_date,
                date_of_birth = user.date_of_birth,
                mobile_number = user.mobile_number,
                password = user.password,
                profile_image_url = user.profile_image_url,
                updated_at = user.updated_at,
            }).ToList();
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            if(userDto.id == null)
                throw new ArgumentException("User ID cannot be null for update operation.");

            await _unitOfWork.Users.UpdateAsync(new user
            {
                id = (int)userDto.id,
                name = userDto.name,
                email = userDto.email,
                signup_date = userDto.signup_date,
                role = userDto.role,
                updated_at = userDto.updated_at,
                profile_image_url = userDto.profile_image_url,
                date_of_birth = userDto.date_of_birth,
                password = userDto.password,
                mobile_number = userDto.mobile_number,
            });
            await _unitOfWork.CompleteAsync();
        }
    }
}
