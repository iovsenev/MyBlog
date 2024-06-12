using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using System.Text.RegularExpressions;

namespace MyBlog.Domain.ValueObjects;

public record PhoneNumber
{
    private const string regexValidationPhone = @"^((8 |\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    private PhoneNumber(string phoneNumber)
    {
        Phone = phoneNumber;
    }

    public string Phone { get; }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        if(string.IsNullOrEmpty(input.Trim()))
            return Errors.General.InValid(input);

        if(!Regex.IsMatch(input, regexValidationPhone))
            return Errors.General.InValid(input);

        return new PhoneNumber(input);
    }
}