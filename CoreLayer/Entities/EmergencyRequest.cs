using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmergencyRequest
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public DateTime RaisedAt { get; set; }
        public string SymptomsText { get; set; }
        public int? AnalysisID { get; set; }
        public string AIResponseJSON { get; set; }
        public bool DoctorEscalated { get; set; }

        public User? User { get; set; }
        public SkinAnalysis? SkinAnalysis { get; set; }
    }
}
