using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkinZone : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AnalysisZoneScore> AnalysisZoneScores { get; set; } = new List<AnalysisZoneScore>();
        public string Description { get; set; }
    }
}
