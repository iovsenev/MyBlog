using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Api.Models.Users;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Users.Commands.Create;

namespace MyBlog.Api.Controllers;

public class UserController : AppBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices]
        ICommandHandler<CreateUserRequest,Guid> handler,
        [FromBody]
        CreateUserRequest request,
        CancellationToken token = default)

    {
        var result = await handler.Handle(request, token);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromQuery]Guid id, CancellationToken token = default)
    {
        var user = new UserViewModel();

        return Ok(user);
    }
}
