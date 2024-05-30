using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Domain.Entities;

public class Tag
{
    private Tag() { }
    public Tag(string input)
    {
        Name = input;
    }

    public Guid Id { get;private set; }
    public string Name { get;private set; }

    private IReadOnlyList<Article> _articles = [];
    public IReadOnlyList<Article> Articles => _articles;

    public static Result<Tag, Error> Create(string input)
    {
        input = input.Trim();

        if(string.IsNullOrEmpty(input))
            return Errors.General.InValid(input);

        return new Tag(input);
    }
}