using FluentValidation.Results;
using LocalFriendzApi.Core.Validations;

namespace LocalFriendzApi.Core.Requests.Contact
{
    public class UpdateContactRequest
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? DDD { get; set; }
        public string? Email { get; set; }

        public ValidationResult Validator()
        {
            return new UpdateContactRequestValidator().Validate(this);
        }
    }
}
