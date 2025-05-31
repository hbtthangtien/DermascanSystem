using Domain.Commons;
using Domain.Enums;

namespace Domain.Entities
{
    public class SubscriptionPlan : BaseEntity
    {
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
