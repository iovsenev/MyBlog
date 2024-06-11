using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;
using MyBlog.Persistence.Repositories.Users;
using MyBlog.Persistence.Repositories.Users.Queries.GetAllUserByPage;
using MyBlog.Persistence.Repositories.Users.Queries.GetUserById;

namespace MyBlog.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<AppWriteDbContext>();
        services.AddSingleton<AppReadDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        //services.AddScoped<IArticleRepository, ArticleRepository>();

        services.AddScoped<IQueryHandler<GetAllUsersByPageRequest, ICollection<AppUserDto>>, GetAllUsersByPageQuery>();
        services.AddScoped<IQueryHandler<Guid, AppUserDto>, GetUserByIdQuery>();

        return services;
    }
}
