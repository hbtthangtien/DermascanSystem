using Application.DTOs.Common;
using Domain.ExceptionCustom;
using System.Security.Authentication;

namespace Presentation.Middleware
{
    public class ExceptionCatchGlobal
    {
        private readonly RequestDelegate _next;

        public ExceptionCatchGlobal(RequestDelegate request)
        {
            _next = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AuthenticationException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(BaseResponse<AuthenticationException>.ErrorResponse(ex.Message));
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(BaseResponse<NotFoundException>.ErrorResponse(ex.Message));
            }
            catch (DuplicateException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(BaseResponse<DuplicateException>.ErrorResponse(ex.Message));
            }catch(BusinessException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(BaseResponse<DuplicateException>.ErrorResponse(ex.Message));
            }
        }
    }
}
