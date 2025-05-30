using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSubscription
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int PlanID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public SubscriptionPlan Plan { get; set; }
    }
}
