using Application.DTOs.Common;
using Application.DTOs.Token;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;
using Application.Services;
using Domain.Configs;
using Domain.Entities;
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

        public Task<BaseResponse<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IdResponse> RevokeToken(RevokeTokenDTO dto)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateRefreshToken(long userId, int expireDay)
        {
            var random = new byte[128];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                string token = Convert.ToBase64String(random);
                
                return token;
            }
        }

    }
}
