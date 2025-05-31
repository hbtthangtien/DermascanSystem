using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class PagingResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PagingResponse() { }

        public PagingResponse(PaginationRequest request, int totalRecords)
        {
            PageNumber = request.PageIndex;
            PageSize = request.PageSize;
            TotalRecords = totalRecords;
        }
    }
}
