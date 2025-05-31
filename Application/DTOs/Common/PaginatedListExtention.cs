using Application.Paginated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public static class PaginatedListExtention
    {
        public static PaginatedList<TDestination> Map<TSource, TDestination>(
           this PaginatedList<TSource> source,
           Func<TSource, TDestination> mapFunc, int count)
        {
            var mappedItems = source.Select(mapFunc).ToList();
            return PaginatedList<TDestination>.Create(mappedItems, count, source.PageIndex, source.PageSize);
        }

        public static PagingResponse ConvertToPagingResponse<T>(PaginatedList<T> dto)
        {
            return new PagingResponse
            {
                PageNumber = dto.PageIndex,
                PageSize = dto.PageSize,
                TotalRecords = dto.TotalCount,
            };
        }
    }
}
