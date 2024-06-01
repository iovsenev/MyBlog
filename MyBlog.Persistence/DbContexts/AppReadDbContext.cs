using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.EntityConfigurations.Read;

namespace MyBlog.Persistence.DbContexts;

public class AppReadDbContext : DbContext, IReadDbContext
{
    private readonly IConfiguration _configuration;

    public AppReadDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<ArticleDto> Articles { get; set; }

    public DbSet<AppUserDto> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleEntityConfiguration).Assembly, 
            type => type.FullName.Contains("EntityConfigurations.Read"));
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DatabaseAccess"));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
