using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SkinAnalysic
{
    public class SkinZoneAnalysisDto
    {
        public string Zone { get; set; }
        public int Score { get; set; }
        public string Recommendation { get; set; }
    }
}
