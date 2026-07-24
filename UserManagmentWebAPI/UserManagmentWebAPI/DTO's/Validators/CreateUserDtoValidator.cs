using FluentValidation;
using UserManagmentWebAPI.DTO_s.Authentication;

namespace UserManagementWebAPI.DTO_s.Validators
{
    public class CreateUserDtoValidator:AbstractValidator<CreateUserRequest>
    {
        public CreateUserDtoValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop; //Check the text box one by one

            RuleFor(x => x.FullName)
                          .NotEmpty().WithMessage("Full name is required.")
                          .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                          .NotEmpty().WithMessage("Email is required.")
                          .EmailAddress().WithMessage("Please enter a valid email address.")
                          .MaximumLength(256).WithMessage("Email must not exceed 256 characters.");

            RuleFor(x => x.UserName)
                          .NotEmpty().WithMessage("Username is required.")
                          .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.")
                          .Matches(@"^[a-zA-Z0-9_.]+$").WithMessage("Username can only contain letters, numbers, dots, and underscores.");

            RuleFor(x => x.Contact)
                          .NotEmpty().WithMessage("Contact is required.")
                          .Matches(@"^\d{11}$").WithMessage("Contact must be exactly 11 digits.");

            RuleFor(x => x.Password)
                          .NotEmpty().WithMessage("Password is required.")
                          .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                          .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                          .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                          .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
                          .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Address)
                          .MaximumLength(250).WithMessage("Address must not exceed 250 characters.");
            //RuleFor(x => x.Role)
            //              .IsInEnum()
            //              .WithMessage("Invalid role selected.");
        }
    }
}
