using Domain.Commons;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public long UserID { get; set; }
        public long ProductID { get; set; }
        public long? AnalysisID { get; set; }
        public long PartnerID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CommissionEarned { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public User? User { get; set; }
        public Product? Product { get; set; }
        public SkinAnalysis? Analysis { get; set; }
        public Partner? Partner { get; set; }
    }
}
