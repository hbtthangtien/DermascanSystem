using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubscriptionPlan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public BillingCycle BillingCycle { get; set; }
        public int GracePeriodDays { get; set; }
        public int ResultRetentionDays { get; set; }
        public int FreeUsageLimitPerWeek { get; set; }

        public ICollection<SkinAnalysis> SkinAnalyses { get; set; } = new List<SkinAnalysis>();
        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();    
    }
}
