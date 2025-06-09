using Application.DTOs.Common;
using Application.DTOs.SubscriptionPlan;
using Application.DTOs.VietQr;
using Application.Extentions;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Application.Services;
using Azure.Core;
using Domain.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class VietQrService : BaseService,IVietQrServices
    {
        private readonly VietQrConfig vietConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISubscriptionPlanService _subscriptionPlanService;
        private readonly IUserContextService _userContextService;
        public VietQrService(IOptions<VietQrConfig> options,
            IHttpClientFactory httpClientFactory,
            IUnitOfWork unitOfWork,
            ISubscriptionPlanService subscriptionPlanService,
            IUserContextService userContextService) : base(unitOfWork)
        {
            vietConfig = options.Value;
            _httpClientFactory = httpClientFactory;
            _subscriptionPlanService = subscriptionPlanService;
            _userContextService = userContextService;
        }
        public async Task<BaseResponse<ResponseVietQr>> GenerateVietQrCode(PurchasePlan plan)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                await _unitOfWork.BeginTransactionAsync();
                var userId = _userContextService.GetUserId();
                var userPlanId = await _subscriptionPlanService.MakeOrderPlan(userId, plan.PlanId);
                var addInfor = $"MUA-GOI-UID{userId}-PID{plan.PlanId}-UPID{userPlanId}";
                var amount = await _unitOfWork.Subscriptions
                    .GetInstance()
                    .Where(e => e.Id == plan.PlanId)
                    .Select(e => e.Price)
                    .FirstOrDefaultAsync();
                var body = new
                {
                    accountNo = vietConfig.AccountNo,
                    accountName = vietConfig.AccountName,
                    acqId = vietConfig.AcqId,
                    format = vietConfig.Format,
                    template = vietConfig.Template,
                    AddInfo = addInfor,
                    Amount = amount,
                };
                var response = await client.PostAsJsonAsync(vietConfig.Url, body);
                var result = await response.Content.ReadFromJsonAsync<ResponseVietQr>();
                await _unitOfWork.CommitTransactionAsync();
                return BaseResponse<ResponseVietQr>.SuccessResponse(result!);
            }catch(Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ExceptionFactory.Business(ex.Message);
            }
            
        }
    }
}
