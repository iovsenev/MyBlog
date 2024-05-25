using FluentValidation;
using MyBlog.Contracts.Articles.Requests;

namespace MyBlog.Application.Validators.Article
{
    public class CreateArticleRequestValidator : AbstractValidator<CreateArticleRequest>
    {
        public CreateArticleRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull();
        }
    }
}
