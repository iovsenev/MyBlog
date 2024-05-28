using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Articles.Command.Create;

public class CreateArticleHandler : IRequestHandler<CreateArticleRequest, Result>
{
    private readonly IWriteDbContext _dbContext;

    public CreateArticleHandler(IWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> Handle(CreateArticleRequest request, CancellationToken cancellationToken)
    {
        var resultArticle = Article.Create(request.Title, request.Description, request.Text);

        if (resultArticle.IsFailure)
            return Result.Failure(resultArticle.Error.Serialize());

        await _dbContext.Articles.AddAsync(resultArticle.Value, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
