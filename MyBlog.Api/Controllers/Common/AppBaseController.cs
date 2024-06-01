using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Helpers;
using MyBlog.Domain.Common;

namespace MyBlog.Api.Controllers.Common;

[ApiController]
[Route("[controller]")]
public abstract class AppBaseController : ControllerBase
{
    protected new IActionResult Ok(object? result = null)
    {
        var envelope = ResponseFormat.Ok(result);

        return base.Ok(envelope);
    }

    protected IActionResult BadRequest(Error error)
    {
        var errors = new Dictionary<string, string[]>();

        errors.Add(error.ErrorCode, new[] { error.Message});

        var envelope = ResponseFormat.Error(errors);

        return base.BadRequest(envelope);
    }
}
