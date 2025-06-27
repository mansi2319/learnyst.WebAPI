using learnyst.Core.Interfaces;
using learnyst.Infrastructure.Data;
using learnyst.Infrastructure.Repositories;

namespace learnyst.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
