using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Roboflow
{
    public class InferenceResult : IdRequest
    {
        public double Time { get; set; }
        public ImageDetails Image { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
