using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AIRecommendation
    {
        public long Id { get; set; }
        public long AnalysisID { get; set; }
        public RecommendationType RecommendationType { get; set; }
        public string Message { get; set; }
        public long? ProductID { get; set; }

        public SkinAnalysis? Analysis { get; set; }
        public Product? Product { get; set; }
    }
}
