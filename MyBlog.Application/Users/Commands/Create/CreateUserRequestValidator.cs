using FluentValidation;

namespace MyBlog.Application.Users.Commands.Create;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(u => u.emailInput)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
        RuleFor(u => u.passwordHash)
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.userName)
            .NotEmpty()
            .NotNull();
    }
}
