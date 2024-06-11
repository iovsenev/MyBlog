using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Controllers.Common;
using MyBlog.Api.Mappings;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Application.Services.Users.Create;
using MyBlog.Domain.Entities.ReadEntity;
using MyBlog.Domain.Entities.WriteEntity;
using MyBlog.Persistence.Repositories.Users.Queries.GetAllUserByPage;

namespace MyBlog.Api.Controllers;

public class UserController : AppBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices]
        IQueryHandler<GetAllUsersByPageRequest, ICollection<AppUserDto>> handler,
        [FromQuery]
        GetAllUsersByPageRequest request,
        CancellationToken token = default)
    {
        var result = await handler.Handle(request, token);
        if (result.IsFailure)
            return BadRequest(result.Error);

        var users = result.Value
            .Select(u => u.ToShortUserViewModel());

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices]
        ICommandHandler<CreateUserRequest> handler,
        [FromBody]
        CreateUserRequest request,
        CancellationToken token = default)

    {
        var result = await handler.Handle(request, token);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet("/{id}")]

    public async Task<IActionResult> Get(
        [FromServices]
        IQueryHandler<Guid, AppUserDto> handler,
        Guid id,
        CancellationToken token = default)
    {
        var user = await handler.Handle(id, token);

        if (user.IsFailure)
            return BadRequest(user.Error);

        //var userVM = user.Value.ToUserSingleViewModel();

        return Ok(user.Value);
    }
}
