using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Services
{
    public class BundleService : IBundleService
    {
        private readonly IGenericRepository<bundle> _bundleRepository;

        public BundleService(IGenericRepository<bundle> bundleRepository)
        {
            _bundleRepository = bundleRepository;
        }

        public async Task<BundleDto> GetByIdAsync(int id)
        {
            var user = await _bundleRepository.GetByIdAsync(id);
            if (user == null) return new BundleDto();
            return new BundleDto
            {
                id = user.id, 
            }; 
        }

        public async Task AddAsync(BundleDto bundleDto)
        {
            await _bundleRepository.AddAsync(new bundle() { id = bundleDto.id });
        }

        public async Task DeleteAsync(int id)
        {
            await _bundleRepository.DeleteAsync(id);
        }

        public async Task<List<BundleDto>> GetAllAsync()
        {
            var courses = await _bundleRepository.ListAllAsync();
            return courses.Select(user => new BundleDto
            {
                id = user.id
            }).ToList();
        }

        public async Task UpdateAsync(BundleDto bundleDto)
        {
            await _bundleRepository.UpdateAsync(new bundle
            {
                id = bundleDto.id
            });
        }
    }
}
