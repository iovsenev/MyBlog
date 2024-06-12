using CSharpFunctionalExtensions;
using MyBlog.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using MyBlog.Domain.Common;
using System.ComponentModel;

namespace MyBlog.Domain.Entities.WriteEntity;

public class AppUser
{
    private const PhoneNumber _defaultPhone = PhoneNumber.Create("79998887766").Value;
    private AppUser() { }

    private AppUser(
        string userName,
        string passwordHash,
        string email,
        DateTimeOffset registrationDate,
        PhoneNumber number )
    {
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        RegistrationDate = registrationDate;
        Phone = number;
    }

    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string SecondName { get; private set; } = string.Empty;
    public DateTimeOffset BirthDate { get; private set; } 
    public DateTimeOffset RegistrationDate { get; private set; }


    private readonly List<Article> _articles = [];
    public IReadOnlyList<Article> Articles => _articles;


    private readonly List<Comment> _comments = [];
    public IReadOnlyList<Comment> Comments => _comments;


    public static Result<AppUser, Error> Create(
        string userName,
        string passwordHash,
        string emailInput)
    {
        emailInput = emailInput.Trim().ToLower();
        var emailResult = EmailObject.Create(emailInput);
        if (emailResult.IsFailure) return emailResult.Error;

        userName = userName.Trim().ToLower();
        if (string.IsNullOrEmpty(userName))
            userName = emailResult.Value.Email;

        passwordHash = passwordHash.Trim();
        if (string.IsNullOrEmpty(passwordHash))
            return Errors.General.InValid(passwordHash);

        return new AppUser(
            userName,
            passwordHash,
            emailResult.Value.Email,
            DateTimeOffset.UtcNow,
            _defaultPhone);
    }

    public void PublishArticle(Article article)
    {
        _articles.Add(article);
    }
}
