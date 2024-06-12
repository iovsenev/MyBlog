using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using System.Text.RegularExpressions;

namespace MyBlog.Domain.ValueObjects;

public class EmailObject
{
    private const string Pattern = "(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$)";

    private EmailObject(string input)
    {
        Email = input;
    }

    public string Email { get; private set; }

    public static Result<EmailObject, Error> Create(string input)
    {
        input = input.Trim();
        if (string.IsNullOrEmpty(input))
            return Errors.General.InValid(input);
        if (!Regex.IsMatch(input, Pattern))
            return Errors.General.InValid(input);
        return new EmailObject(input);
    }

    public override bool Equals(object? obj)
    {
        if (obj is EmailObject)
            return Email == ((EmailObject)obj).Email;
        return false;
    }
}
