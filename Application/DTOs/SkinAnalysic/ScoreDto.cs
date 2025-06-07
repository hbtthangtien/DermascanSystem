using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SkinAnalysic
{
    public class ScoreDto
    {
        public int Overall { get; set; }
        public int Acne { get; set; }
        public int Moisture { get; set; }
        public int Pigmentation { get; set; }
        public int Wrinkle { get; set; }
        public int Pore { get; set; }
        public int Sensitivity { get; set; }
        public int Aging { get; set; }
    }
}
