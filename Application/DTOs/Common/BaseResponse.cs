using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
        public Dictionary<string, string>? Errors { get; set; }
        public PagingResponse? Paging { get; set; }

        // Success response method with optional paging and message
        public static BaseResponse<T> SuccessResponse(T data, PagingResponse? paging = null, string? message = null)
        {
            return new BaseResponse<T>
            {
                Success = true,
                Data = data,
                Paging = paging,
                Message = message ?? string.Empty,
                Errors = null
            };
        }

        // Error response method with optional errors
        public static BaseResponse<T> ErrorResponse(string message, Dictionary<string, string>? errors = null)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors,
                Data = default
            };
        }
    }
}
