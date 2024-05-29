using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Articles.Dtos;
using MyBlog.Application.Users.DTOS;

namespace MyBlog.Application.Interfaces.DataAccess
{
    public interface IReadDbContext
    {
        public DbSet<GetArticleDto> Articles { get; set; }
        public DbSet<AppUserDto> Users { get; set; }
    }
}
