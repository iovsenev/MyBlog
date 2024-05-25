using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBlog.Domain.Entities;
using MyBlog.Persistence.EntityConfigurations;

namespace MyBlog.Persistence.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
