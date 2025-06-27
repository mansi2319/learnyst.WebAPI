using learnyst.Core.Entities;

namespace learnyst.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> CompleteAsync();

        //IGenericRepository<user> Users { get; } 
        //Task<int> CompleteAsync(); 
    }
}
