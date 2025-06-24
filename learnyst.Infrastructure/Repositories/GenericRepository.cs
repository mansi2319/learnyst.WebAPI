using learnyst.Core.Interfaces;
using learnyst.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace learnyst.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id) =>
            await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> ListAllAsync() =>
            await _context.Set<T>().ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = _context.Set<T>().FindAsync(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Attach(entityToDelete);
            }
            _context.Remove(entityToDelete);


            //Delete(entityToDelete);

            //_context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
