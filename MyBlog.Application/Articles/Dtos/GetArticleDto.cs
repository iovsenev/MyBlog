using MyBlog.Application.Comments.Dtos;
using MyBlog.Application.Users.DTOS;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Application.Articles.Dtos;

public class GetArticleDto
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
    public IEnumerable<GetCommentDto> Comments { get; set; }
}
