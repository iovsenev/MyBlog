using MyBlog.Api.Models.Articles;
using MyBlog.Application.Articles.Dtos;

namespace MyBlog.Api.Mappings;

public static class Articles
{
    public static ArticleViewModelForList ToArticleListViewModel(this GetArticleDto article)
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