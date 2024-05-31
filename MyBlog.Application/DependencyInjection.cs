using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Articles.Command.Create;
using MyBlog.Application.Articles.Queries.GetAllArticles;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Users.Commands.Create;
using MyBlog.Application.Users.Queries.GetAllUsers;
using MyBlog.Application.Validators;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace MyBlog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<
            IQueryHandler<GetAllArticlesRequest, GetAllArticleResponse>, 
            GetAllArticleQueryHandler>();
        services.AddScoped<
            IQueryHandler<GetAllUsersRequest, GetAllUsersResponse>,
            GetAllUsersHandler>();

        services.AddScoped<
            ICommandHandler<CreateArticleRequest, Guid>, 
            CreateArticleHandler>();
        services.AddScoped<
            ICommandHandler<CreateUserRequest, Guid>, 
            CreateUserHandler>();


        services.AddValidatorsFromAssembly(typeof(CreateArticleRequestValidator).Assembly);
        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });

        return services;
    }
}
