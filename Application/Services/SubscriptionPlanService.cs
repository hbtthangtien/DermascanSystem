using Application.DTOs.Common;
using Application.DTOs.SubscriptionPlan;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubscriptionPlanService : BaseService, ISubscriptionPlanService
    {
        private IUserContextService _userContextService;
        public SubscriptionPlanService(IUnitOfWork unitOfWork, IUserContextService userContextService) : base(unitOfWork)
        {
            _userContextService = userContextService;
        }

        public async Task<BaseResponse<List<ResponsePlanDTO>>> GetAllPlan()
        {
            var currentPlanId = _userContextService.GetPlanId();
            var dtos = await _unitOfWork.Subscriptions.GetAllAsync()
                        .Where( e => e.Id>currentPlanId && e.DeletedAt == null)
                        .ProjectToType<ResponsePlanDTO>()
                        .ToListAsync();
            return BaseResponse<List<ResponsePlanDTO>>.SuccessResponse(dtos);
        }

        public async Task<long> MakeOrderPlan(long planId, long userId)
        {
            var planReview = await _unitOfWork.Subscriptions
                .GetInstance()
                .Where(e => e.Id == planId)
                .Select(e => new SubscriptionPlan
                {
                    Id = e.Id,
                    Price = e.Price,
                    ResultRetentionDays = e.ResultRetentionDays
                })
                .FirstOrDefaultAsync();
            var now = DateTime.Now;
            var userPlan = new UserSubscription
            {
                PlanID = planId,
                StartDate = now,
                EndDate = now.AddDays(planReview!.ResultRetentionDays),
                Status = Domain.Enums.UserPlanStatus.Pending,
                UserID = userId
            };
            await _unitOfWork.UserSubsciptions.AddAsync(userPlan);
            await _unitOfWork.SaveChangeAsync();
            return userPlan.Id;
        }
    }
}
