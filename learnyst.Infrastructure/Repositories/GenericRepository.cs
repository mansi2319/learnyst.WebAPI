using learnyst.Core.Interfaces;
using learnyst.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            // Get the primary key value using reflection (assumes property named "Id" or "id")
            var keyProperty = typeof(T).GetProperty("Id") ?? typeof(T).GetProperty("id");
            if (keyProperty == null)
                throw new InvalidOperationException("No property named 'Id' or 'id' found on type " + typeof(T).Name);

            var idValue = keyProperty.GetValue(entity);

            // Check if already tracked
            var trackedEntity = _context.ChangeTracker.Entries<T>()
                .FirstOrDefault(e => keyProperty.GetValue(e.Entity)?.Equals(idValue) == true);

            if (trackedEntity != null)
            {
                // Detach the existing tracked instance
                _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
            }

            // Attach and update the new entity
            _context.Entry(entity).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _context.Set<T>().FindAsync(id);

            if (entityToDelete == null)
                throw new Exception("Entity not found");

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Attach(entityToDelete);
            }
            _context.Remove(entityToDelete);
        }
    }
}
