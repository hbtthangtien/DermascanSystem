using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configs
{
    public class VietQrConfig
    {
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public long AcqId { get; set; }
        public string Format { get; set; }
        public string Template { get; set; }

        public string Url { get; set; }
    }
}
