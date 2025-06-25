using learnyst.Application.DTOs;
using learnyst.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace learnyst.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiveKitController : Controller
    {
        private readonly ILiveKitTokenService _tokenService;

        public LiveKitController(ILiveKitTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("token")]
        public IActionResult GetToken([FromBody] TokenRequestDto request)
        {
            var token = _tokenService.GenerateToken(request.Identity, request.RoomName);
            return Ok(new { token });
        }
    }
}
