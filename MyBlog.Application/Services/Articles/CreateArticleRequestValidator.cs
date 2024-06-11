using FluentValidation;

namespace MyBlog.Application.Services.Articles;
public class CreateArticleRequestValidator : AbstractValidator<CreateArticleRequest>
{
    public CreateArticleRequestValidator()
    {
        RuleFor(r => r.AuthorId).NotEqual(Guid.Empty);
        RuleFor(r => r.Tittle).NotEmpty().NotNull();
        RuleFor(r => r.Text).NotEmpty().NotNull();
    }
}
