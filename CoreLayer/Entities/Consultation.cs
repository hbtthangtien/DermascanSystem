using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Consultation
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
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
