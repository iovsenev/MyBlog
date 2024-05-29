using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities;

public class Article
{
    private Article() { }
    private Article(
        Guid id,
        string title,
        string description,
        string text,
        DateTimeOffset addedDate,
        int likes,
        int dislikes,
        Guid authorId
        )
    {
        Id = id;
        Title = title;
        Description = description;
        Text = text;
        AddedDate = addedDate;
        Likes = likes;
        Dislikes = dislikes;
        AuthorId = authorId;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Text { get; private set; }
    public DateTimeOffset AddedDate { get; private set; }
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }

    public Guid AuthorId { get; private set; }
    [ForeignKey(nameof(AuthorId))]
    public AppUser Author { get; set; }

    private IReadOnlyList<Comment> _comments = [];
    public IReadOnlyList<Comment> Comments => _comments;

    //public IReadOnlyList<Tag> Tags { get; set; }


    public static Result<Article, Error> Create(
        Guid authorId,
        string title,
        string description,
        string text
        )
    {
        var id = Guid.NewGuid();

        if (string.IsNullOrEmpty(title.Trim()))
            return Errors.General.InValid(title);

        if (string.IsNullOrEmpty(description.Trim()))
            return Errors.General.InValid(description);

        if (string.IsNullOrEmpty(text.Trim()))
            return Errors.General.InValid(text);

        var addedDate = DateTimeOffset.UtcNow;

        return new Article(id, title, description, text, addedDate, 0, 0, authorId);
    }
}