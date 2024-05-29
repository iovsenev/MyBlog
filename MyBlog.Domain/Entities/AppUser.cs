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
        string email,
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
    [Required, EmailAddress]
    public string Email { get; private set; }
    [Required]
    public Phone Phone { get; private set; }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? SecondName { get; private set; }
    public DateTimeOffset BirthDate { get; private set; }
    public DateTimeOffset RegistrationDate { get; private set; }

    public List<Article> Articles { get; private set; }
    public List<Comment> Comments { get; private set; }

    //public Result<AppUser, Error> Create(CreateAppUserRequest input)
    //{
    //    var id = Guid.NewGuid();
    //    var userName = input.UserName;
    //    var passwordHash = input.PasswordHash;
    //    var email = input.Email;
    //    string firstName;
    //    string lastName;
    //    string secondName;
    //    DateTime birthDate = input.BirthDate;

    //    if (string.IsNullOrEmpty(email))
    //        return Errors.General.InValid(email);

    //    if (string.IsNullOrEmpty(userName))
    //        userName = input.Email;

    //    if (string.IsNullOrEmpty(passwordHash))
    //        return Errors.General.InValid(passwordHash);

    //    if (string.IsNullOrEmpty(input.FirstName.Trim()))
    //        firstName = "";
    //    else
    //        firstName = input.FirstName;

    //    if (string.IsNullOrEmpty(input.SecondName))
    //        secondName = "";
    //    else
    //        secondName = input.SecondName;

    //    if (!string.IsNullOrEmpty(input.LastName.Trim()))
    //        lastName = "";
    //    else
    //        lastName = input.LastName;

    //    if (birthDate > maxDate && birthDate < minDate)
    //        return Errors.General.InValid(birthDate);

    //    var phone = Phone.Create(input.Phone);
    //    if (phone.IsFailure)
    //        return phone.Error;

    //    return new AppUser(
    //        id,
    //        userName,
    //        passwordHash,
    //        email,
    //        firstName,
    //        lastName,
    //        secondName,
    //        birthDate,
    //        phone.Value,
    //        DateTimeOffset.UtcNow);
    //}
}
