using Application.DTOs.Common;
using Application.DTOs.SubscriptionPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ISubscriptionPlanService
    {
        public Task<BaseResponse<List<ResponsePlanDTO>>> GetAllPlan();
    }
}
