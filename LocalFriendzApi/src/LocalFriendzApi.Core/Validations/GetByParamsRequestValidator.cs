using FluentValidation;

namespace LocalFriendzApi.Core.Requests.Contact
{
    public class GetByParamsRequestValidator : AbstractValidator<GetByParamsRequest>
    {
        public GetByParamsRequestValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
