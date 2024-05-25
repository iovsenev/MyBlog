using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Contracts.Articles.Requests;

namespace MyBlog.Api.Controllers
{
    public class ArticleController : AppBaseController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetArticlesByPageRequest request,  CancellationToken ct = default)
        {
            var result = await _articleService.GetAll(request, ct);

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
}
