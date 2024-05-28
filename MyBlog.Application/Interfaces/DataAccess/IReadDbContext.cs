using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Articles.Dtos;

namespace MyBlog.Application.Interfaces.DataAccess
{
    public interface IReadDbContext
    {
        public DbSet<GetArticleDto> Articles { get; }
    }
}
