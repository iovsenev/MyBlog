using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IWriteDbContext, AppWriteDbContext>();
        services.AddSingleton<IReadDbContext, AppReadDbContext>();


        return services;
    }
}
