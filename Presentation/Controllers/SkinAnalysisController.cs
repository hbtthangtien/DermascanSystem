using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/skin-analysis")]
    [ApiController]
    public class SkinAnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;
        public SkinAnalysisController(IAnalysisService aIAnalysisService)
        {
            _analysisService = aIAnalysisService;
        }
        [HttpPost("scan")]
        public async Task<IActionResult> ScanAnalysicImage(IFormFile file)
        {
            var data = await _analysisService.ScanFaceAnalysic(file);
            return Ok(data);
        }
    }
}
