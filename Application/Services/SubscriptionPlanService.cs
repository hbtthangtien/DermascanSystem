using Application.DTOs.Common;
using Application.DTOs.SubscriptionPlan;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
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
        public SubscriptionPlanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<BaseResponse<List<ResponsePlanDTO>>> GetAllPlan()
        {
            var dtos = await _unitOfWork.Subscriptions.GetAllAsync()
                        .Where(e => e.DeletedAt == null)
                        .ProjectToType<ResponsePlanDTO>()
                        .ToListAsync();
            return BaseResponse<List<ResponsePlanDTO>>.SuccessResponse(dtos);
        }
    }
}
