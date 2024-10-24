using FluentValidation;
using LocalFriendzApi.Core.Requests.Contact;

namespace LocalFriendzApi.Core.Validations
{
    public class UpdateContactRequestValidator : AbstractValidator<UpdateContactRequest>
    {
        public UpdateContactRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\d{8,9}$").WithMessage("Phone number must be a valid Brazilian phone number with 8 or 9 digits (e.g., 912345678).");

            RuleFor(x => x.DDD)
                .NotEmpty().WithMessage("DDD is required.")
                .Length(2).WithMessage("DDD must be exactly 2 characters long.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("A valid email is required.")
                .EmailAddress().WithMessage("A valid email is required.");
        }
    }
}
