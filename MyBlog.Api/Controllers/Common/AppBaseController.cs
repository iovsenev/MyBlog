using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Halpers;

namespace MyBlog.Api.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AppBaseController : ControllerBase
    {
        protected new IActionResult Ok(object? result = null)
        {
            var envelope = Envelope.Ok(result);

            return base.Ok(envelope);
        }

        protected new IActionResult BadRequest(Dictionary<string, string[]>? errors = null)
        {
            var envelope = Envelope.Error(errors);

            return base.BadRequest(envelope);
        }
    }
}
