using Application.DTOs.Roboflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SkinAnalysic
{
    public class CreateAnalysicDTO
    {
        public string MediaPath { get; set; }

        public SkinAnalysisDto SkinAnalysis { get; set; }

        public InferenceResult InferenceResult { get; set; }
    }
}
