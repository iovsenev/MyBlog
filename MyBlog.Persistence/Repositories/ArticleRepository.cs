using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities;
using MyBlog.Persistence.DbContexts;
using MyBlog.Application.Interfaces.DataAccess;

namespace MyBlog.Persistence.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppWriteDbContext _context;

        public ArticleRepository(AppWriteDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Create(Article article, CancellationToken ct = default)
        {

            await _context.Articles.AddAsync(article, ct);
            await _context.SaveChangesAsync(ct);

            return Result.Success();
        }

        public async Task<Result> Delete(Guid id, CancellationToken ct = default)
        {
            var entity = await _context.Articles.FindAsync(id, ct);

            if (entity == null)
            {
                return Result.Failure(Errors.General.NotFound(id).Serialize());
            }

            _context.Remove(entity);
            _context.SaveChangesAsync(ct);

            return Result.Success();
        }

        public async Task<Result<Article, Error>> GetById(Guid id, CancellationToken ct = default)
        {
            var entity = await _context.Articles.FindAsync(id, ct);

            if (entity == null)
            {
                return Errors.General.NotFound(id);
            }

            return entity;
        }

        public async Task<Result<IReadOnlyList<Article>, Error>> GetAll(int page, int sizePage, CancellationToken ct = default)
        {
            return await _context.Articles
                .AsNoTracking()
                .Skip((page - 1) * sizePage)
                .Take(sizePage)
                .ToListAsync(ct);
        }

    }
}
