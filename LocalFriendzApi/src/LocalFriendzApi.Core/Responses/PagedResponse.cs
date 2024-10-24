using LocalFriendzApi.Core.Configuration;
using System.Text.Json.Serialization;

namespace LocalFriendzApi.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
        TData? data,
        int totalCount,
        int currentPage = 1,
        int pageSize = ConfigurationPage.DefaultPageSize,
        string? message = null)
        : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Message = message;
        }

        public PagedResponse(
            TData? data,
            int code = ConfigurationPage.DefaultStatusCode,
            string? message = null)
            : base(data, code, message)
        {
        }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = ConfigurationPage.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
