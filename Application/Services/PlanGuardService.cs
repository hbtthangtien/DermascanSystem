using Application.Extentions;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlanGuardService : BaseService, IPlanGuardService
    {
        private readonly IUserContextService userContext;
        public PlanGuardService(IUnitOfWork unitOfWork, IUserContextService userContext) : base(unitOfWork)
        {
            this.userContext = userContext;
        }

        public async Task ValidateAsync()
        {
            var userId = userContext.GetUserId();
            var planId = userContext.GetPlanId();
            var now = DateTime.Now;
            var sub = await _unitOfWork.UserSubsciptions
                        .GetInstance()
                        .Include(e => e.Plan)
                        .Where(e =>
                           e.UserID == userId
                        && e.PlanID == planId
                        && e.DeletedAt == null
                        && e.Status == Domain.Enums.UserPlanStatus.Active
                        && e.StartDate <= now
                        && (e.EndDate == null || e.EndDate >= now)
                        )
                        .FirstOrDefaultAsync()
                        ?? throw ExceptionFactory.PlanException(Domain.Enums.UserPlanCodeException.PlanExpiredOrNotOwned);


            // count number of scan per week
            if (planId <= 2 && planId > 0)
            {
                var startOfWeek = DateTime.Now.Date;
                var daysToSubtract = (startOfWeek.DayOfWeek - DayOfWeek.Monday + 7) % 7;
                startOfWeek = startOfWeek.AddDays(-daysToSubtract);
                var numberOfScanThisWeek = await _unitOfWork.SkinAnalysses
                    .GetInstance()
                    .CountAsync(e=> e.UserID == userId
                            && e.PlanID == planId
                            && e.CapturedAt >= startOfWeek);
                if(numberOfScanThisWeek > sub.Plan.FreeUsageLimitPerWeek)
                {
                    throw ExceptionFactory.PlanException(Domain.Enums.UserPlanCodeException.WeeklyQuotaExceeded);
                }
            }
        }
    }
}
