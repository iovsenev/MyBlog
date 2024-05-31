using MyBlog.Application.Articles.Dtos;

namespace MyBlog.Application.Articles.Queries.GetAllArticles;

public record GetAllArticleResponse(List<GetArticleDto> Articles, int count);