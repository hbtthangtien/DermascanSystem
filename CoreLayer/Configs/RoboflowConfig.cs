using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configs
{
    public class RoboflowConfig
    {
        public string ApiKey { get; set; }
        public string ProjectName { get; set; }
        public string Version { get; set; }
        public string EndPoint { get; set; }
    }
}
