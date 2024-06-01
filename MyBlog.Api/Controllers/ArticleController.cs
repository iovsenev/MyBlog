﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Persistence.Queries.Articles.GetAllArticles;
using MyBlog.Persistence.Repositories.Articles.Create;

namespace MyBlog.Api.Controllers;

public class ArticleController : AppBaseController
{

    public ArticleController()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] 
        IQueryHandler<GetAllArticlesRequest, GetAllArticleResponse> query,
        [FromQuery]
        GetAllArticlesRequest request, 
        CancellationToken ct = default)
    {
        var result = await query.Handle(request, ct);

        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value.Articles);
    }

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
