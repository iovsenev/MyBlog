﻿using FluentValidation;

namespace MyBlog.Persistence.Repositories.Articles.Create
{
    public class CreateArticleRequestValidator : AbstractValidator<CreateArticleRequest>
    {
        public CreateArticleRequestValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEqual(Guid.Empty);
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