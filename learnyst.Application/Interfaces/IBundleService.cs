using learnyst.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Interfaces
{
    public interface IBundleService
    {
        public Task<BundleDto> GetByIdAsync(int id);
        public Task<List<BundleDto>> GetAllAsync();
        Task AddAsync(BundleDto bundleDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(BundleDto bundleDto);
    }
}
