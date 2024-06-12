using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBlog.Domain.Entities.WriteEntity;
using MyBlog.Persistence.EntityConfigurations.Write;

namespace MyBlog.Persistence.DbContexts;

public class AppWriteDbContext : DbContext
{
    public AppWriteDbContext(DbContextOptions<AppWriteDbContext> options) : base(options)
    {
    }

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleEntityConfiguration).Assembly,
            type => type.FullName.Contains("MyBlog.Persistence.EntityConfigurations.Write"));
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
