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
        private readonly IGenericRepository<Users> _genericRepository;

        public UserService(IGenericRepository<Users> userRepository)
        {
            _genericRepository = userRepository;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _genericRepository.GetByIdAsync(id);
            if (user == null) return new UserDto();
            return new UserDto
            {
                id = user.id, 
                created_at = user.created_at,
                email = user.email,
                name = user.name,
                role = user.role?.ToString()
            }; 
        }

        //public async Task CreateUserAsync(CreateUserDto dto)
        //{
        //    var user = new User { Id = Guid.NewGuid(), Name = dto.Name };
        //    await _genericRepository.AddAsync(user);
        //}
    }
}
