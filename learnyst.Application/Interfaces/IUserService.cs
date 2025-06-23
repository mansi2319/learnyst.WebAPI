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
        public Task<UserDto> GetUserAsync(int id);
    }
}
