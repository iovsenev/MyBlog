using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Interfaces.DataAccess
{
    public interface IWriteDbContext
    {
        public DbSet<Article> Articles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
