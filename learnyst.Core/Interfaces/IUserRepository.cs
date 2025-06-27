using learnyst.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<user>
    {
        Task<user> FindByEmailAsync(string email);
    }
}
