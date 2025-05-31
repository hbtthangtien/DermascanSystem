using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class PaginationRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string? OrderBy { get; set; }
        public bool IsDesc { get; set; } = false;
        public string? SearchString { get; set; } = string.Empty;
    }
}
