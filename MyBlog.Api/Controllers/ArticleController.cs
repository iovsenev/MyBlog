using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Contracts.Articles.Requests;
using MyBlog.Persistence.Queries;

namespace MyBlog.Api.Controllers;

public class ArticleController : AppBaseController
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] GetArticleQuery query,
        [FromQuery]GetAllArticlesByPageRequest request, 
        CancellationToken ct = default)
    {
        var result = await query.Handle(request, ct);

        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] 
        CreateArticleRequest request, 
        CancellationToken ct = default)
    {
        var result = await _articleService.Create(request, ct);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
