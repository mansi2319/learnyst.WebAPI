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
    public class BatchService : IBatchService
    {
        private readonly IGenericRepository<batch> _batchRepository;

        public BatchService(IGenericRepository<batch> batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<BatchDto> GetByIdAsync(int id)
        {
            var user = await _batchRepository.GetByIdAsync(id);
            if (user == null) return new BatchDto();
            return new BatchDto
            {
                id = user.id, 
            }; 
        }

        public async Task AddAsync(BatchDto batchDto)
        {
            await _batchRepository.AddAsync(new batch() { id = batchDto.id });
        }

        public async Task DeleteAsync(int id)
        {
            await _batchRepository.DeleteAsync(id);
        }

        public async Task<List<BatchDto>> GetAllAsync()
        {
            var courses = await _batchRepository.ListAllAsync();
            return courses.Select(user => new BatchDto
            {
                id = user.id
            }).ToList();
        }

        public async Task UpdateAsync(BatchDto courseDto)
        {
            await _batchRepository.UpdateAsync(new batch
            {
                id = courseDto.id
            });
        }
    }
}
