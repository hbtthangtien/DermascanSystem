using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string AffiliateURL { get; set; }
        public string ImageURL { get; set; }
        public decimal? Price { get; set; }
        public long? PartnerID { get; set; }
        public bool IsActive { get; set; }
        public Partner? Partner { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<AIRecommendation> AIRecommendations { get; set; } = new List<AIRecommendation>();
    }
}
