using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgressPhoto : BaseEntity
    {
        public long UserID { get; set; }
        public DateTime TakenAt { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
        public long? AnalysisID { get; set; }
        public User? User { get; set; }
        public SkinAnalysis? Analysis { get; set; }
    }
}
