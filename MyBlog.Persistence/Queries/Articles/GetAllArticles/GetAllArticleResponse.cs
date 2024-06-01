using MyBlog.Domain.Entities.ReadEntity;

namespace MyBlog.Persistence.Queries.Articles.GetAllArticles;

public record GetAllArticleResponse(List<ArticleDto> Articles, int count);