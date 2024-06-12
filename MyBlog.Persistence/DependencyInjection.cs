using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.DbContexts;
using MyBlog.Persistence.Repositories.Articles.Queries.GetAllArticle;
using MyBlog.Persistence.Repositories.Users;
using MyBlog.Persistence.Repositories.Users.Queries.GetAllUserByPage;
using MyBlog.Persistence.Repositories.Users.Queries.GetUserById;

namespace MyBlog.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configure)
    {
        services.AddDbContext<AppWriteDbContext>(builder =>
        {
            builder.UseNpgsql(configure.GetConnectionString("DatabaseAccess"));
        });
        services.AddDbContext<AppReadDbContext>(configureation =>
        {
            configureation.UseNpgsql(configure.GetConnectionString("DatabaseAccess"));
        });

        services.AddScoped<IUserRepository, UserRepository>();


        services.AddScoped<IQueryHandler<GetAllUsersByPageRequest, ICollection<AppUserDto>>, GetAllUsersByPageQuery>();
        services.AddScoped<IQueryHandler<Guid, AppUserDto>, GetUserByIdQuery>();
        services.AddScoped<IQueryHandler<GetArticleRequest, ICollection<ArticleDto>>, GetAllArticleQuery>();

        return services;
    }
}
