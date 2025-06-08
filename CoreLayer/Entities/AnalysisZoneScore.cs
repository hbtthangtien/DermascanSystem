using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalysisZoneScore : BaseEntity
    {
        public long ZoneID { get; set; }
        public byte Score { get; set; }
        public long SkinAnalysisId { get; set; }
        public SkinAnalysis? SkinAnalysis { get; set; }
        public SkinZone? Zone { get; set; }
    }
}
