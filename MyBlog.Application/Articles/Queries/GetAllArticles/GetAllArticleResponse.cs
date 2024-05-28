using MyBlog.Application.Articles.Dtos;

namespace MyBlog.Application.Articles.Queries.GetArticles;

public record GetAllArticleResponse(List<GetArticleDto> Articles, int count);