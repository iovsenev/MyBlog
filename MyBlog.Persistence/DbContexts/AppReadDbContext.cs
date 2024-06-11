using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.EntityConfigurations.Read;

namespace MyBlog.Persistence.DbContexts;

public class AppReadDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppReadDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<ArticleDto> Articles => Set<ArticleDto>();

    public DbSet<AppUserDto> Users => Set<AppUserDto>();

    public DbSet<CommentDto> Comments => Set<CommentDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleReadEntityConfiguration).Assembly,
            type => type.FullName.Contains("EntityConfigurations.Read"));
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DatabaseAccess"));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
