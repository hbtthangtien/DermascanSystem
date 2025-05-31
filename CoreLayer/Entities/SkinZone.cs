using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkinZone
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<AnalysisZoneScore> AnalysisZoneScores { get; set; } = new List<AnalysisZoneScore>();
    }
}
