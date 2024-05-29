using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using MyBlog.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Domain.Entities;

public class AppUser
{
    private readonly DateTime minDate = new DateTime(1920, 1, 1);
    private readonly DateTime maxDate = DateTime.UtcNow;
    private AppUser() { }

    private AppUser(
        Guid id,
        string userName,
        string passwordHash,
        EmailObject email,
        string firstName,
        string lastName,
        string secondName,
        DateTimeOffset birthDate,
        Phone phone,
        DateTimeOffset registrationDate)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        Phone = phone;
        FirstName = firstName;
        LastName = lastName;
        SecondName = secondName;
        BirthDate = birthDate;
        RegistrationDate = registrationDate;
    }

    public Guid Id { get; private set; }
    [Required]
    public string UserName { get; private set; }
    [Required]
    public string PasswordHash { get; private set; }
    [Required]
    public EmailObject Email { get; private set; }
    [Required]
    public Phone Phone { get; private set; }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? SecondName { get; private set; }
    public DateTimeOffset BirthDate { get; private set; }
    public DateTimeOffset RegistrationDate { get; private set; }

    private IReadOnlyList<Article> _articles = [];
    public IReadOnlyList<Article> Articles => _articles;

    private IReadOnlyList<Comment> _comments = [];
    public IReadOnlyList<Comment> Comments => _comments;

    public Result<AppUser, Error> Create(
        string userName,
        string passwordHash,
        string emailInput,
        string firstName,
        string secondName,
        string lastName,
        string phoneInput,
        DateTime birthDate
        )
    {
        var id = Guid.NewGuid();

        var emailReslt = EmailObject.Create(emailInput);

        if (emailReslt.IsFailure)
            return Errors.General.InValid(emailInput);

        userName = userName.Trim();
        if (string.IsNullOrEmpty(userName))
            userName = emailReslt.Value.Email;

        passwordHash = passwordHash.Trim();
        if (string.IsNullOrEmpty(passwordHash))
            return Errors.General.InValid(passwordHash);

        firstName = firstName.Trim();
        if (string.IsNullOrEmpty(firstName))
            firstName = "";

        secondName = secondName.Trim();
        if (string.IsNullOrEmpty(secondName))
            secondName = "";

        lastName = lastName.Trim();
        if (!string.IsNullOrEmpty(lastName))
            lastName = "";

        if (birthDate > maxDate && birthDate < minDate)
            return Errors.General.InValid(birthDate);

        var phone = Phone.Create(phoneInput);
        if (phone.IsFailure)
            return phone.Error;

        return new AppUser(
            id,
            userName,
            passwordHash,
            emailReslt.Value,
            firstName,
            lastName,
            secondName,
            birthDate,
            phone.Value,
            DateTimeOffset.UtcNow);
    }
}
