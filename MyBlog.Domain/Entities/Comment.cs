using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities;

public class Comment
{
    private Comment() { }

    private Comment(
        Guid id, 
        string text, 
        int likes, 
        int dislikes, 
        DateTimeOffset addedDate
        )
    {
        this.id = id;
        Text = text;
        Likes = likes;
        Dislikes = dislikes;
        AddedDate = addedDate;
    }


    public Guid id { get; private set; }
    public string Text { get; private set; }
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }
    public DateTimeOffset AddedDate { get; private set; }

    public Guid AutorId {  get; private set; }
    [ForeignKey(nameof(AutorId))]
    public AppUser Author { get; private set; }

    public Guid ArticleId { get; private set; }
    [ForeignKey(nameof(ArticleId))]
    public Article Article { get; private set; }

    public static Comment Create(
        Guid author,
        Guid article
        )
    { return new Comment(); }
}