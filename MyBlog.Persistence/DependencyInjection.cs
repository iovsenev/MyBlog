using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Services.Users.Create;
using MyBlog.Persistence.DbContexts;
using MyBlog.Persistence.Queries.Articles.GetAllArticles;
using MyBlog.Persistence.Queries.Users.GetAllUsers;
using MyBlog.Persistence.Repositories.Articles;
using MyBlog.Persistence.Repositories.Articles.Create;
using MyBlog.Persistence.Repositories.Users;
using MyBlog.Persistence.Repositories.Users.Create;

namespace MyBlog.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton< AppWriteDbContext>();
        services.AddSingleton< AppReadDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IArticleRepository, ArticleRepository>();


        return services;
    }
}
