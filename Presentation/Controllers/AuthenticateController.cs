using Application.DTOs.Authenticate;
using Application.DTOs.Token;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IJwtService _jwtService;
        public AuthenticateController(IAuthenticateService authenticateService, IJwtService jwtService)
        {
            _authenticateService = authenticateService;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var data = await _authenticateService.Login(login);
            return Ok(data);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequestDTO request)
        {
            var data = await _jwtService.RefreshToken(request);
            return Ok(data);
        }

        [HttpDelete("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(RevokeTokenDTO request)
        {
            var data = await _jwtService.RevokeToken(request);
            return Ok(data);
        }
    }
}
