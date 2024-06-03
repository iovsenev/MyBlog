using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.WriteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services.Articles;
public class CreateArticleHandler : ICommandHandler<CreateArticleRequest, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateArticleHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateArticleRequest request, CancellationToken cancellationToken)
    {
        var findUserResult = await _userRepository.GetById(request.AuthorId,cancellationToken);

        if (findUserResult.IsFailure)
            return findUserResult.Error;

        var user = findUserResult.Value;

        var createArticleResult = Article.Create(
            request.Tittle,
            request.Description,
            request.Text);

        if (createArticleResult.IsFailure)
            return createArticleResult.Error;

        user.PublishArticle(createArticleResult.Value);

        var idResult = await _userRepository.Save(user);

        if (idResult.IsFailure)
            return idResult.Error;

        return idResult;
    }
}
