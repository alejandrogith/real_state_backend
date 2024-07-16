
using FluentValidation;

namespace real_state_backend.src.Users.Application.Command.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(x => Guid.TryParse(x, out var _))
                .WithMessage(x => "The value {PropertyName} is not a valid uuid");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Email)
              .EmailAddress()
              .WithMessage("{PropertyName} must be a valid format");

        }
    }
}


