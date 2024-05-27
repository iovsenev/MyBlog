using CSharpFunctionalExtensions;
using MyBlog.Contracts.Articles.DTOS;
using MyBlog.Contracts.Articles.Requests;
using MyBlog.Contracts.Articles.Response;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Interfaces.Services;

public interface IArticleService
{
    Task<Result> Create(CreateArticleRequest request, CancellationToken ct = default);
    Task<Result> Delete(Guid id, CancellationToken ct = default);
    Task<Result<IEnumerable<Article>, Error>> GetAll(GetAllArticlesByPageRequest request, CancellationToken ct = default);
    Task<Result<Article, Error>> GetById(Guid id, CancellationToken ct = default);
}