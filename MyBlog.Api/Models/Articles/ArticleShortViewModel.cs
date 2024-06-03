using MyBlog.Domain.Entities.WriteEntity;

namespace MyBlog.Api.Models.Articles;

public record ArticleShortViewModel(
    Guid id,
    string Title,
    string Description,
    DateTime AddedDate,
    int likes,
    int dislikes,
    ICollection<Tag> Tags);
