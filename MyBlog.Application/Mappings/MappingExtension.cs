using MyBlog.Contracts.Articles.Response;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Mappings
{
    public static class MappingExtension
    {
        public static ResponseArticle ArticleToResponseArticle(this Article article)
        {
            var response = new ResponseArticle(
                article.Id, 
                article.Title,
                article.Description,
                article.Text,
                article.Likes,
                article.Dislikes,
                article.AddedDate,
                "author");

            return response;
        }
    }
}
