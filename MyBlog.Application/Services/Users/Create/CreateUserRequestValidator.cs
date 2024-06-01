using FluentValidation;
using MyBlog.Application.Services.Users.Create;

namespace MyBlog.Persistence.Repositories.Users.Create;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(u => u.emailInput)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
        RuleFor(u => u.password)
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.userName)
            .NotEmpty()
            .NotNull();
    }
}
