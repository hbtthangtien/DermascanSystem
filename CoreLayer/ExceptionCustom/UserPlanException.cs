using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionCustom
{
    public class UserPlanException : Exception
    {

        public UserPlanCodeException Code { get; }
        public UserPlanException()
        {
        }

        public UserPlanException(string? message, UserPlanCodeException code) : base(message)
        {
            Code = code;
        }

        public UserPlanException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserPlanException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
