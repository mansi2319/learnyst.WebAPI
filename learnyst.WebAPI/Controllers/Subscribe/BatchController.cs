using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers.Subscribe
{
    [ApiController]
    [Route("api/[controller]/")]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        #region Batch
        [Route("GetBatchById")]
        [HttpGet]
        public async Task<IActionResult> GetBatchById(int id) =>
            Ok(await _batchService.GetByIdAsync(id));

        [Route("GetAllBatches")]
        [HttpGet]
        public async Task<IActionResult> GetAllBatches() =>
            Ok(await _batchService.GetAllAsync());

        [Route("AddBatch")]
        [HttpPost]
        public async Task<IActionResult> AddBatch(BatchDto batchDto)
        {
            await _batchService.AddAsync(batchDto);
            return Ok(batchDto);
        }

        [Route("UpdateBatch")]
        [HttpPut]
        public async Task<IActionResult> UpdateBatch(BatchDto batchDto)
        {
            await _batchService.UpdateAsync(batchDto);
            return Ok(batchDto);
        }

        [Route("DeleteBatch")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            await _batchService.DeleteAsync(id);
            return Ok(id);
        }
        #endregion
    }
}
