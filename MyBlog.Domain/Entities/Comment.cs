using MyBlog.Contracts.Comments.Requests;

namespace MyBlog.Domain.Entities;

public class Comment
{
    private Comment() { }

    private Comment(
        Guid id, 
        string text, 
        int likes, 
        int dislikes, 
        DateTimeOffset addedDate, 
        AppUser author, 
        Article article)
    {
        this.id = id;
        Text = text;
        Likes = likes;
        Dislikes = dislikes;
        AddedDate = addedDate;
        Author = author;
        Article = article;
    }


    public Guid id { get; private set; }
    public string Text { get; private set; }
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }
    public DateTimeOffset AddedDate { get; private set; }


    public AppUser Author { get; private set; }

    public Article Article { get; private set; }

    public static Comment Create(
        AppUser author,
        Article article,
        CreateCommentRequest request)
    { return new Comment(); }
}