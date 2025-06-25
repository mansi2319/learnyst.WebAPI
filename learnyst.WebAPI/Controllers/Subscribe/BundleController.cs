using learnyst.Application.DTOs;
using learnyst.Application.Interfaces;
using learnyst.Core.Entities;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers.Subscribe
{
    [ApiController]
    [Route("api/[controller]/")]
    public class BundleController : ControllerBase
    {
        private readonly IBundleService _bundleService;
        public BundleController(IBundleService bundleService)
        {
            _bundleService = bundleService;
        }

        #region Course
        [Route("GetBundleById")]
        [HttpGet]
        public async Task<IActionResult> GetBundleById(int id) =>
            Ok(await _bundleService.GetByIdAsync(id));

        [Route("GetAllBundles")]
        [HttpGet]
        public async Task<IActionResult> GetAllBundles() =>
            Ok(await _bundleService.GetAllAsync());

        [Route("AddBundle")]
        [HttpPost]
        public async Task<IActionResult> AddBundle(BundleDto bundleDto)
        {
            await _bundleService.AddAsync(bundleDto);
            return Ok(bundleDto);
        }

        [Route("UpdateBundle")]
        [HttpPut]
        public async Task<IActionResult> UpdateBundle(BundleDto bundleDto)
        {
            await _bundleService.UpdateAsync(bundleDto);
            return Ok(bundleDto);
        }

        [Route("DeleteBundle")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBundle(int id)
        {
            await _bundleService.DeleteAsync(id);
            return Ok(id);
        }
        #endregion
    }
}
