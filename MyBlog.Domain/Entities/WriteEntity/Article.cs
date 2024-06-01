using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities.WriteEntity;

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
        int dislikes
        )
    {
        Id = id;
        Title = title;
        Description = description;
        Text = text;
        AddedDate = addedDate;
        Likes = likes;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Text { get; private set; }
    public DateTimeOffset AddedDate { get; private set; }
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }

    public AppUser Author { get; private set; }

    private IReadOnlyList<Comment> _comments = [];
    public IReadOnlyList<Comment> Comments => _comments;

    private IReadOnlyList<Tag> _tags = [];
    public IReadOnlyList<Tag> Tags => _tags;


    public static Result<Article, Error> Create(
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

        return new Article(id, title, description, text, addedDate, 0, 0);
    }
}