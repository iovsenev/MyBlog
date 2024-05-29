using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Articles.Command.Create;
using MyBlog.Application.Articles.Queries.GetArticles;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Validators;
using MyBlog.Domain.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace MyBlog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<
                IQueryHandler<GetAllArticlesRequest, GetAllArticleResponse>, 
                GetAllArticleQueryHandler>();
            services.AddScoped<
                ICommandHandler<CreateArticleRequest, Guid>, 
                CreateArticleHandler>();
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
