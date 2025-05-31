using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DiaryEntry : BaseEntity
    {
        public long UserID { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal? WaterIntakeL { get; set; }
        public decimal? SleepHours { get; set; }
        public string Notes { get; set; }
        public string AIComment { get; set; }
        public string Mood { get; set; }

        public User? User { get; set; }
    }
}
