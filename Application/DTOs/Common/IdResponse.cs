using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class IdResponse:BaseResponse<long>
    {
        public long Id { set; get; }
        public static IdResponse SuccessResponse(long id, string message, Dictionary<string, string>? error = null)
        {
            return new IdResponse { Id = id, Message = message, Success = true, Errors = error };
        }
        public static IdResponse ErrorResponse(long id, string message, Dictionary<string, string>? error = null)
        {
            return new IdResponse { Id = id, Message = message, Success = false, Errors = error };
        }
    }
}
