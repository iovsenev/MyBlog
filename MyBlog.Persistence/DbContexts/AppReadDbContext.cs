using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.EntityConfigurations.Read;

namespace MyBlog.Persistence.DbContexts;

public class AppReadDbContext : DbContext
{
    public AppReadDbContext(DbContextOptions<AppReadDbContext> option) : base(option)
    {
    }

    public DbSet<ArticleDto> ArticleDTOs => Set<ArticleDto>();
    public DbSet<AppUserDto> UserDTOs => Set<AppUserDto>();
    public DbSet<CommentDto> CommentDTOs => Set<CommentDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleReadEntityConfiguration).Assembly,
            type => type.FullName.Contains("EntityConfigurations.Read"));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
