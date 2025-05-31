using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmergencyRequest
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public DateTime RaisedAt { get; set; }
        public string SymptomsText { get; set; }
        public long? AnalysisID { get; set; }
        public string AIResponseJSON { get; set; }
        public bool DoctorEscalated { get; set; }

        public User? User { get; set; }
        public SkinAnalysis? SkinAnalysis { get; set; }
    }
}
