using Application.DTOs.Authenticate;
using Application.DTOs.Common;
using Application.DTOs.Token;
using Application.Extentions;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticateService : BaseService, IAuthenticateService
    {
        private readonly IJwtService _jwtService;
        public AuthenticateService(IUnitOfWork unitOfWork,IJwtService jwtService) : base(unitOfWork)
        {
            _jwtService = jwtService;
        }

        public async Task<BaseResponse<TokenResponseDTO>> Login(LoginDTO dto)
        {
            var account = _unitOfWork.Accounts.GetInstance()
                            .Include(e => e.User)
                                .ThenInclude(e => e.UserSubscriptions
                                .Where(us => us.Status == Domain.Enums.UserPlanStatus.Active && us.DeletedAt == null))
                            .Include(e => e.Doctor)                            
                            .FirstOrDefault(e => e.Email == dto.Email)
                            ?? throw ExceptionFactory.Business("Email không tồn tại. Vui lòng thử lại");
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, account.HashPassword))
                throw ExceptionFactory.Business("Email hoặc password chưa chính xác. Vui lòng thử lại");            
            var token = account.Adapt<ClaimToken>();
            token.FullName = account.User != null ? account.User.FullName : (account.Doctor != null ? account.Doctor.FullName : "");
            token.PlanID = account.User!.UserSubscriptions.ElementAt(0).PlanID;
            token.UserId = account.User!.Id;
            var jwt = await _jwtService.GenerateTokenAsync(token);
            return jwt;
        }
    }
}
