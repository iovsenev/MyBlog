using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Application.Articles.Command.Create;
using MyBlog.Application.Articles.Queries.GetArticles;
using MyBlog.Application.Interfaces.Services;

namespace MyBlog.Api.Controllers;

public class ArticleController : AppBaseController
{

    public ArticleController()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllArticleResponse> query,
        [FromQuery]GetAllArticlesRequest request, 
        CancellationToken ct = default)
    {
        var result = await query.Handle(request, ct);

        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices]
        IMediator mediator,
        [FromBody] 
        CreateArticleRequest request, 
        CancellationToken ct = default)
    {
        var result = await _articleService.Create(request, ct);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
