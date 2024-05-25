using MyBlog.Domain.Entities;

namespace MyBlog.Application.Interfaces.DataAccess
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
