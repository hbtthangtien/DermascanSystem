using Application.DTOs.Authenticate;
using Application.DTOs.Common;
using Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IAuthenticateService
    {
        Task<BaseResponse<TokenResponseDTO>> Login(LoginDTO dto);
    }
}
