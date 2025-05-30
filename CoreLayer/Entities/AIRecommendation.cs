using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AIRecommendation
    {
        public int Id { get; set; }
        public int AnalysisID { get; set; }
        public RecommendationType RecommendationType { get; set; }
        public string Message { get; set; }
        public int? ProductID { get; set; }

        public SkinAnalysis? Analysis { get; set; }
        public Product? Product { get; set; }
    }
}
