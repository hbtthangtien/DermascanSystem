using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgressPhoto
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public DateTime TakenAt { get; set; }
        public string ImagePath { get; set; }
        public long? AnalysisID { get; set; }

        public User? User { get; set; }
        public SkinAnalysis? Analysis { get; set; }
    }
}
