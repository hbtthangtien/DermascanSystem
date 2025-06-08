using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetAccountId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                var userIdClaim = user.FindFirst("sub") ?? user.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    return long.Parse(userIdClaim.Value);
                }
            }
            return 0;
        }

        public long GetPlanId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                var plainId = _httpContextAccessor.HttpContext?.User.FindFirstValue("PlanId");
                if(plainId != null)
                {
                    return long.Parse(plainId); 
                }

                
            }
            return 0;
        }

        public long GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                var plainId = _httpContextAccessor.HttpContext?.User.FindFirstValue("UserId");
                if (plainId != null)
                {
                    return long.Parse(plainId);
                }


            }
            return 0;
        }
    }
}
