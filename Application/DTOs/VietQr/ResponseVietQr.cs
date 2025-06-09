using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.VietQr
{
    public class ResponseVietQr
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public VietQrData? Data { get; set; }

        public class VietQrData
        {
            public string QrDataURL { get; set; }
            public string QrRawData { get; set; }
            public string AddInfo { get; set; }
        }
    }
}
