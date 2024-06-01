using MyBlog.Domain.Entities.WriteEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities.ReadEntity;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Text { get; set; }
    public DateTimeOffset AddedDate { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public Guid AuthorId { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public AppUserDto Author { get; set; }
    public ICollection<CommentDto> Comments { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
