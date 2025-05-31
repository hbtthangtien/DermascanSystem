using Application.DTOs.Common;
using Application.DTOs.Token;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IJwtService
    {
        public Task<BaseResponse<TokenResponseDTO>> GenerateTokenAsync(ClaimToken token);

        public Task<BaseResponse<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO dto);

        public Task<IdResponse> RevokeToken(RevokeTokenDTO dto);
    }
}
