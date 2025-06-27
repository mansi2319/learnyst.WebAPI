using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using learnyst.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<user>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<user> FindByEmailAsync(string email)
        {
            return await _context.users
                .FirstOrDefaultAsync(u => u.email == email) ?? new user();
        }
    }
}
