using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Persistence.Repositories.Articles.Create;

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
}
