using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int? AnalysisID { get; set; }
        public int PartnerID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CommissionEarned { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderedAt { get; set; }

        public User? User { get; set; }
        public Product? Product { get; set; }
        public SkinAnalysis? Analysis { get; set; }
        public Partner? Partner { get; set; }
    }
}
