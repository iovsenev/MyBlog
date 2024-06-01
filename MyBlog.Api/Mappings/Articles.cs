using MyBlog.Api.Models.Articles;
using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Api.Mappings;

public static class Articles
{
    public static ArticleViewModelForList ToArticleListViewModel(this ArticleDto article)
    {
        return new ArticleViewModelForList(
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