using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;

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
                title = user.title,
                course_id = user.course_id,
                end_date = user.end_date,
                instructor_id = user.instructor_id,
                price = user.price,
                start_date = user.start_date,
            }; 
        }

        public async Task AddAsync(BatchDto batchDto)
        {
            await _batchRepository.AddAsync(
                new batch() { 
                    start_date = batchDto.start_date,
                    course_id = batchDto.course_id,
                    end_date = batchDto.end_date,
                    instructor_id = batchDto.instructor_id,
                    price = batchDto.price,
                    title = batchDto.title
                });
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
                id = user.id,
                title = user.title,
                course_id = user.course_id,
                end_date = user.end_date,
                instructor_id = user.instructor_id,
                price = user.price,
                start_date = user.start_date,
            }).ToList();
        }

        public async Task UpdateAsync(BatchDto batchDto)
        {
            if (batchDto.id == null)
                throw new ArgumentException("Batch ID cannot be null for update operation.");

            await _batchRepository.UpdateAsync(new batch
            {
                id = (int)batchDto.id,
                start_date = batchDto.start_date,
                course_id = batchDto.course_id,
                end_date = batchDto.end_date,
                instructor_id = batchDto.instructor_id,
                price = batchDto.price,
                title = batchDto.title,
            });
        }
    }
}
