using MyBlog.Application.Comments.Dtos;
using MyBlog.Application.Users.DTOS;
using MyBlog.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Api.Models.Articles;

public record ArticleViewModelForList(
    Guid id,
    string Title,
    string Description,
    DateTime AddedDate,
    int likes,
    int dislikes,
    ICollection<Tag> Tags);
