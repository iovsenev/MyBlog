using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Application.Interfaces.Services;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Persistence.Repositories.Articles.Create;

public class CreateArticleHandler : ICommandHandler<CreateArticleRequest, Guid>
{
    private readonly IWriteDbContext _dbContext;

    public CreateArticleHandler(IWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Guid, Error>> Handle(CreateArticleRequest request, CancellationToken cancellationToken)
    {
        var author = await _dbContext.Users.FindAsync(request.AuthorId);

        if (author is null)
            return Errors.General.NotFound();

        var resultArticle = Article.Create(author.Id, request.Title, request.Description, request.Text);
        if (resultArticle.IsFailure)
            return resultArticle.Error;

        //author.Articles.Add(resultArticle.Value);

        await _dbContext.Articles.AddAsync(resultArticle.Value, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return resultArticle.Value.Id;
    }
}
