using learnyst.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Interfaces
{
    public interface IBatchService
    {
        public Task<BatchDto> GetByIdAsync(int id);
        public Task<List<BatchDto>> GetAllAsync();
        Task AddAsync(BatchDto batchDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(BatchDto batchDto);
    }
}
