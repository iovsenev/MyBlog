using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyBlog.Domain.Entities;
using MyBlog.Persistence.EntityConfigurations.Write;

namespace MyBlog.Persistence.DbContexts;

public class AppWriteDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppWriteDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<AppUser> Users => Set<AppUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleEntityConfiguration).Assembly,
            type => type.FullName.Contains("EntityConfigurations.Write")); ;
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DatabaseAccess"));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
