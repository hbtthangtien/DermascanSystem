using Domain.Enums;
using Domain.ExceptionCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{

    public static class ExceptionFactory
    {
        public static BusinessException Business(string message) =>
            new BusinessException(message);

        public static NotFoundException NotFound(string entity, object key) =>
            new NotFoundException($"{entity} with key {key} was not found.");

        public static DuplicateException Conflict(string entity, string field) =>
            new DuplicateException($"{entity} already exists for {field}.");

        public static UserPlanException PlanException(UserPlanCodeException code)
        {
            return code switch
            {
                UserPlanCodeException.PlanExpiredOrNotOwned => new UserPlanException("Your plan is expired date or not your own", UserPlanCodeException.PlanExpiredOrNotOwned),
                UserPlanCodeException.WeeklyQuotaExceeded => new UserPlanException("Too many request in this time, please try later!!!", UserPlanCodeException.WeeklyQuotaExceeded),
                _ => new UserPlanException("An unknown error occurred", UserPlanCodeException.Other)
            };
        }
    }

}
