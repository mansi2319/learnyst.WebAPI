using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using learnyst.Infrastructure.Data;
using learnyst.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private GenericRepository<user>? _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context; 
        }

        public IGenericRepository<user> Users => _userRepository ??= new GenericRepository<user>(_context);

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
