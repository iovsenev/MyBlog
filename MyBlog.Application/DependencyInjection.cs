using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Services;
using MyBlog.Application.Validators;
using MyBlog.Application.Validators.Article;
using MyBlog.Contracts.Articles.Requests;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace MyBlog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();

            services.AddValidatorsFromAssembly(typeof(CreateArticleRequestValidator).Assembly);
            services.AddFluentValidationAutoValidation(configuration =>
            {
                configuration.DisableBuiltInModelValidation = true;
                configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            });

            return services;
        }
    }
}
