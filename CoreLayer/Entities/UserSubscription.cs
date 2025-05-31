using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSubscription : BaseEntity
    {
        public long UserID { get; set; }
        public long PlanID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public SubscriptionPlan Plan { get; set; }
    }
}
