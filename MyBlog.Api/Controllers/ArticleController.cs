using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Services.Articles;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Persistence.Repositories.Articles.Queries.GetAllArticle;

namespace MyBlog.Api.Controllers;

public class ArticleController : AppBaseController
{

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices]
        ICommandHandler<CreateArticleRequest, Guid> command,
        [FromBody] 
        CreateArticleRequest request, 
        CancellationToken ct = default)
    {
        var result = await command.Handle(request, ct);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices]
        IQueryHandler<GetArticleRequest, ICollection<ArticleDto>> queryHandler,
        CancellationToken token)
    {
        var request = new GetArticleRequest();
        var response = await queryHandler.Handle(request, token);

        return Ok(response.Value);
    }
}
