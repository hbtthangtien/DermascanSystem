using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Partner
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PartnerType PartnerType { get; set; }
        public decimal CommissionRate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
