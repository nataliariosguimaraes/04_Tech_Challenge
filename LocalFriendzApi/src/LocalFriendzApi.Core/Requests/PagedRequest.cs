using LocalFriendzApi.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace LocalFriendzApi.Core.Requests
{
    public class PagedRequest
    {
        [FromQuery(Name = "pageNumber")]
        public int PageSize { get; set; } = ConfigurationPage.DefaultPageSize;

        [FromQuery(Name = "pageSize")]
        public int PageNumber { get; set; } = ConfigurationPage.DefaultPageNumber;
    }
}
