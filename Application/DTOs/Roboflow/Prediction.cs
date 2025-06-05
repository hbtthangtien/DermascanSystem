using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Roboflow
{
    public class Prediction
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Confidence { get; set; }
        public string Class { get; set; }
        public int ClassId { get; set; }
        public string DetectionId { get; set; }
    }
}
