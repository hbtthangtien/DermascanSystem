using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SkinAnalysic
{
    public class SkinAnalysisDto
    {
        public string UserID { get; set; }
        public OverallAnalysisDto OverallAnalysis { get; set; }
        public List<SkinZoneAnalysisDto> SkinZoneAnalysis { get; set; } = new List<SkinZoneAnalysisDto>();
        public List<SuggestedProductDto> SuggestedProducts { get; set; } = new List<SuggestedProductDto>();
        public AdviceDto Advice { get; set; }
    }
}
