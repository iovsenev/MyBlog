using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

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
        int dislikes/*,
        AppUser author*/
        )
    {
        Id = id;
        Title = title;
        Description = description;
        Text = text;
        AddedDate = addedDate;
        Likes = likes;
        Dislikes = dislikes;
        //Author = author;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Text { get; private set; }
    public DateTimeOffset AddedDate { get; private set; }
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }


    public IReadOnlyList<Image> _images = [];
    public IReadOnlyList<Image> Images => _images;

    //public AppUser Author { get; set; }

    //public IReadOnlyList<Comment> Comments { get; set; }

    //public IReadOnlyList<Tag> Tags { get; set; }


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