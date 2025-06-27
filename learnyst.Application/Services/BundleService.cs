using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;

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
                created_at = user.created_at,
                description = user.description,
                price = user.price,
                title = user.title,
                updated_at = user.updated_at,
                course_ids = user.course_ids
            }; 
        }

        public async Task AddAsync(BundleDto bundleDto)
        {
            await _bundleRepository.AddAsync(
                new bundle() { 
                    course_ids = bundleDto.course_ids,
                    created_at = bundleDto.created_at,
                    description = bundleDto.description,
                    price = bundleDto.price,
                    title = bundleDto.title,
                    updated_at = bundleDto.updated_at,
                });
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
                id = user.id,
                created_at = user.created_at,
                description = user.description,
                price = user.price,
                title = user.title,
                updated_at = user.updated_at,
                course_ids = user.course_ids
            }).ToList();
        }

        public async Task UpdateAsync(BundleDto bundleDto)
        {
            if (bundleDto.id == null)
                throw new ArgumentException("Bundle ID cannot be null for update operation.");

            await _bundleRepository.UpdateAsync(new bundle
            {
                id = (int)bundleDto.id,
                course_ids = bundleDto.course_ids,
                created_at = bundleDto.created_at,
                description = bundleDto.description,
                price = bundleDto.price,
                title = bundleDto.title,
                updated_at = bundleDto.updated_at,
            });
        }
    }
}
