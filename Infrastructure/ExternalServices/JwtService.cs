using Application.DTOs.Common;
using Application.DTOs.Token;
using Application.Extentions;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Application.Services;
using Domain.Configs;
using Domain.Entities;
using Domain.ExceptionCustom;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class JwtService : BaseService, IJwtService
    {
        private readonly JwtConfigs jwt;
        public JwtService(IUnitOfWork unitOfWork, IOptions<JwtConfigs> options) : base(unitOfWork)
        {
            jwt = options.Value;
        }

        public async Task<BaseResponse<TokenResponseDTO>> GenerateTokenAsync(ClaimToken dto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()),
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim("Fullname",dto.FullName),
                new Claim(ClaimTypes.Role,dto.Role.ToString()),
                new Claim("PlanId",dto.PlanID.ToString()),
                new Claim("UserId",dto.UserId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Token));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken
                (
                    issuer: jwt.ValidIssuer,
                    audience: jwt.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(jwt.TokenValidityInMinutes),
                    signingCredentials: creds
                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            string refreshToken = await GenerateRefreshToken(dto.Id, jwt.RefreshTokenValidityInDays);
            var data = new TokenResponseDTO
            {
                AccessToken = token,
                RefreshToken = refreshToken,
            };
            return BaseResponse<TokenResponseDTO>.SuccessResponse(data);
        }

        public async Task<BaseResponse<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO dto)
        {
            await CheckValidRefreshToken(dto.RefreshToken);
            var refreshToken = await _unitOfWork.AccountTokens.GetInstance().Where(e => e.Token == dto.RefreshToken).FirstOrDefaultAsync();
            var account = await _unitOfWork.Accounts.GetInstance()
                       .Include(e => e.Doctor)
                       .Include(e => e.User)
                       .ThenInclude(e => e.UserSubscriptions
                                .Where(us => us.Status == Domain.Enums.UserPlanStatus.Active && us.DeletedAt == null))
                       .Where(e => e.Id == refreshToken!.AccountId)
                       .FirstOrDefaultAsync();
            var claimToken = account.Adapt<ClaimToken>();
            claimToken.FullName = account.User != null ? account.User.FullName : (account.Doctor != null ? account.Doctor.FullName : "");
            claimToken.PlanID = account.User!.UserSubscriptions.ElementAt(0).PlanID;
            var token = await GenerateTokenAsync(claimToken!);
            refreshToken!.MarkUpdated(account.Email);
            await _unitOfWork.SaveChangeAsync();
            return token;

        }

        private async Task CheckValidRefreshToken(string refreshToken)
        {
            var token = await _unitOfWork.AccountTokens.GetInstance()
                .Where(e => e.Token == refreshToken)
                .Select(e => new AccountToken
                {
                    ExpiryTime = e.ExpiryTime,
                    Token = e.Token,
                    DeletedAt = e.DeletedAt,
                    UpdatedAt = e.UpdatedAt
                }).FirstOrDefaultAsync()
                ?? throw  ExceptionFactory.NotFound("Token",refreshToken);
            // check expired date
            _ = (token.ExpiryTime <= DateTime.Now) ? throw ExceptionFactory.Business("Token is expired date to use!!!") : token;
            // check refresh token is used
            _ = (token.UpdatedAt != null) ? throw  ExceptionFactory.Business($"Token is used at {token.UpdatedAt}") : token;
            // check refresh token is revoked
            _ = (token.DeletedAt != null) ? throw ExceptionFactory.Business($"Token is revoked at {token.DeletedAt}") : token;
            //
        }

        public Task<IdResponse> RevokeToken(RevokeTokenDTO dto)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateRefreshToken(long accountId, int expireDay)
        {
            var random = new byte[128];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                string token = Convert.ToBase64String(random);
                var refreshToken = new AccountToken
                {
                    Token = token,
                    ExpiryTime = DateTime.Now.AddDays(expireDay),
                    AccountId = accountId,
                };
                await _unitOfWork.AccountTokens.AddAsync(refreshToken);
                await _unitOfWork.SaveChangeAsync();
                return token;
            }
        }

    }
}
