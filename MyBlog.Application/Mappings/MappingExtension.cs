using MyBlog.Contracts.Articles.DTOS;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Mappings;

public static class MappingExtension
{
    public static ArticleDto ToArticleDto(this Article article)
    {
        var response = new ArticleDto(
            article.Id, 
            article.Title,
            article.Description,
            article.Text,
            article.AddedDate,
            article.Likes,
            article.Dislikes,
            "author");

        return response;
    }
}
