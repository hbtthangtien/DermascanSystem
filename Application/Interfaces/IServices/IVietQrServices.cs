using Application.DTOs.Common;
using Application.DTOs.SubscriptionPlan;
using Application.DTOs.VietQr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IVietQrServices
    {
        public Task<BaseResponse<ResponseVietQr>> GenerateVietQrCode(PurchasePlan purchase);
    }
}
