using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public long AccountId { get; set; }
        public string FullName { get; set; }
        public string LicenseNo { get; set; }
        public string Specialty { get; set; }
        public decimal? Rating { get; set; }
        public string Profile { get; set; }
        public Account? Account { get; set; }
        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}
