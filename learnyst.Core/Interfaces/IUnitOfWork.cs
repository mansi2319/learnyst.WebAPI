using learnyst.Core.Entities;

namespace learnyst.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<user> Users { get; } 
        Task<int> CompleteAsync(); 
    }
}
