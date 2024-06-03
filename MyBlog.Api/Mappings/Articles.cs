using MyBlog.Api.Models.Articles;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Api.Mappings;

public static class Articles
{
    public static ArticleShortViewModel ToArticleListViewModel(this ArticleDto article)
    {
        return new ArticleShortViewModel(
            article.Id,
            article.Title,
            article.Description,
            article.AddedDate.Date,
            article.Likes,
            article.Dislikes,
            article.Tags
            );
    }
}