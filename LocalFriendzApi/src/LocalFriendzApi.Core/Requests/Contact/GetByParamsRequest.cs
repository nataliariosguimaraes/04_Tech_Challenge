using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace LocalFriendzApi.Core.Requests.Contact
{
    public class GetByParamsRequest : PagedRequest
    {
        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; set; }

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "name")]
        public string? Name { get; set; }

        [FromQuery(Name = "phone")]
        public string? Phone { get; set; }

        [FromQuery(Name = "ddd")]
        public string? DDD { get; set; }

        [FromQuery(Name = "email")]
        public string? Email { get; set; }

        public ValidationResult Validator()
        {
            return new GetByParamsRequestValidator().Validate(this);
        }
    }
}
