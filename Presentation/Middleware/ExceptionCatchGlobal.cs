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
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(BaseResponse<AuthenticationException>.ErrorResponse(ex.Message));
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(BaseResponse<NotFoundException>.ErrorResponse(ex.Message));
            }
            catch (DuplicateException ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsJsonAsync(BaseResponse<DuplicateException>.ErrorResponse(ex.Message));
            }catch(BusinessException ex)
            {
                context.Response.StatusCode = 422;
                await context.Response.WriteAsJsonAsync(BaseResponse<DuplicateException>.ErrorResponse(ex.Message));
            }catch(UserPlanException ex)
            {
                context.Response.StatusCode = ex.Code switch
                {
                    Domain.Enums.UserPlanCodeException.WeeklyQuotaExceeded => StatusCodes.Status429TooManyRequests,
                    Domain.Enums.UserPlanCodeException.PlanExpiredOrNotOwned => StatusCodes.Status403Forbidden,
                    _ => StatusCodes.Status400BadRequest
                };
                await context.Response.WriteAsJsonAsync(BaseResponse<UserPlanException>.ErrorResponse(ex.Message));
            }
           catch (Exception ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsJsonAsync(BaseResponse<DuplicateException>.ErrorResponse(ex.Message));
            }
        }
    }
}
