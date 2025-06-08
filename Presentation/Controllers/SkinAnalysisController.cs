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
        private readonly IPlanGuardService _planGuardService;
        public SkinAnalysisController(IAnalysisService aIAnalysisService,
              IPlanGuardService planGuardService)
        {
            _analysisService = aIAnalysisService;
            _planGuardService = planGuardService;

        }
        [HttpPost()]
        public async Task<IActionResult> ScanAnalysicImage(IFormFile file)
        {
            var data = await _analysisService.ScanFaceAnalysic(file);
            return Ok(data);
        }
        [HttpPost("validate")]
        public async Task<IActionResult> ValidatePlan()
        {
            await _planGuardService.ValidateAsync();
            return Accepted();
        }
    }
}
