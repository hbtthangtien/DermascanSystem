using Domain.Commons;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Consultation : BaseEntity
    {
        public long UserID { get; set; }
        public long DoctorID { get; set; }
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }
        public int? ActualDuration { get; set; }
        public PricingOptions PricingOption { get; set; }
        public decimal PricePaid { get; set; }
        public string? ReportPDFPath { get; set; }
        public string Status { get; set; }

        public User? User { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
