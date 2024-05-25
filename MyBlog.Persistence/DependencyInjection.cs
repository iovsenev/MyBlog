using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces;
using MyBlog.Persistence.DbContexts;
using MyBlog.Persistence.Repositories;

namespace MyBlog.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));

            });

            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
