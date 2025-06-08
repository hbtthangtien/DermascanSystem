using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/subscription-plan")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;
        private readonly IUserContextService _userContextService;
        public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlanService, IUserContextService userContextService)
        {
            _subscriptionPlanService = subscriptionPlanService;
            _userContextService = userContextService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionPlan()
        {
            var dto = await _subscriptionPlanService.GetAllPlan();
            return Ok(dto);
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(_userContextService.GetPlanId());
        }
    }
}
