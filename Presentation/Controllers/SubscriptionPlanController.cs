using Application.DTOs.SubscriptionPlan;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/subscription-plan")]
    [ApiController]
    [Authorize]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;
        private readonly IVietQrServices _vietQrService;
        public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlanService, IVietQrServices vietQrServices)
        {
            _subscriptionPlanService = subscriptionPlanService;
            _vietQrService = vietQrServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionPlan()
        {
            var dto = await _subscriptionPlanService.GetAllPlan();
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> PurchaseSubscriptionPlan(PurchasePlan request)
        {
            var dto = await _vietQrService.GenerateVietQrCode(request);
            return Ok(dto);
        }
    }
}
