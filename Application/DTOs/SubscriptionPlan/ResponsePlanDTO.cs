using Application.DTOs.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SubscriptionPlan
{
    public class ResponsePlanDTO : IdRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BillingCycle BillingCycle { get; set; }

        public int GracePeriodDays { get; set; }

        public int ResultRetentionDays { get; set; }

        public int FreeUsageLimitPerWeek { get; set; }
    }
}
