﻿using CSharpFunctionalExtensions;
using MyBlog.Contracts.Articles.DTOS;
using MyBlog.Contracts.Articles.Requests;
using MyBlog.Contracts.Articles.Response;
using MyBlog.Domain.Common;

namespace MyBlog.Application.Interfaces.Services;

public interface IArticleService
{
    Task<Result> Create(CreateArticleRequest request, CancellationToken ct = default);
    Task<Result> Delete(Guid id, CancellationToken ct = default);
    Task<Result<ResponseArticle, Error>> GetAll(GetArticlesByPageRequest request, CancellationToken ct = default);
    Task<Result<ArticleDto, Error>> GetById(Guid id, CancellationToken ct = default);
}