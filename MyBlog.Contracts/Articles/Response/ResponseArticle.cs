using MyBlog.Contracts.Articles.DTOS;

namespace MyBlog.Contracts.Articles.Response;

public record ResponseArticle(List<ArticleDto> Articles);