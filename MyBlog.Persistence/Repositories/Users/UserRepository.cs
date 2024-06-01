﻿using CSharpFunctionalExtensions;
using MyBlog.Application.Interfaces.DataAccess;
using MyBlog.Domain.Common;
using MyBlog.Domain.Entities.WriteEntity;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Persistence.Repositories.Users;
public class UserRepository : IUserRepository
{
    private readonly AppWriteDbContext _context;

    public UserRepository(AppWriteDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid, Error>> Create(AppUser user, CancellationToken ct)
    {
        await _context.Users.AddAsync(user, ct);
        var result = await _context.SaveChangesAsync(ct);

        if (result == 0)
            return Errors.General.AddingFalling("User");
        return user.Id;
    }

    public async Task<Result<AppUser, Error>> GetById(Guid id, CancellationToken ct)
    {
        var result = await _context.Users.FindAsync(id, ct);

        if (result is null)
            return Errors.General.NotFound($"User with id: {id}");

        return result;
    }
}
