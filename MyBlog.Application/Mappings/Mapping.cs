using MyBlog.Application.Services;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Mappings
{
    public static class Mapping
    {
        public static ResponseArticle ArticleToResponseArticle(Article article)
        {
            var response = new ResponseArticle();

            return response;
        }
    }
}
