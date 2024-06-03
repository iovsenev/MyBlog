using CSharpFunctionalExtensions;
using MyBlog.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using MyBlog.Domain.Common;

namespace MyBlog.Domain.Entities.WriteEntity;

public class AppUser
{
    private static readonly DateTime minDate = new DateTime(1920, 1, 1);
    private static readonly DateTime maxDate = DateTime.UtcNow;

    private AppUser() { }

    private AppUser(
        string userName,
        string passwordHash,
        string email,
        DateTimeOffset registrationDate)
    {
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        RegistrationDate = registrationDate;
    }

    public Guid Id { get; private set; }
    [Required]
    public string UserName { get; private set; }
    [Required]
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }

    public Phone Phone { get; private set; } 
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string SecondName { get; private set; } = string.Empty;
    public DateTimeOffset BirthDate { get; private set; } = DateTimeOffset.MinValue;
    public DateTimeOffset RegistrationDate { get; private set; }


    private IReadOnlyList<Article> _articles = [];
    public IReadOnlyList<Article> Articles => _articles;


    private IReadOnlyList<Comment> _comments = [];
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
            DateTimeOffset.UtcNow);
    }
}
