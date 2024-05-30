using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;
using System.Text.RegularExpressions;

namespace MyBlog.Domain.ValueObjects;

public class Phone
{
    private const string regexValidationPhone = @"^((8 |\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    private Phone() { }

    private Phone(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public string PhoneNumber { get;} = string.Empty;

    public static Result<Phone, Error> Create(string input)
    {
        if(string.IsNullOrEmpty(input.Trim()))
            return Errors.General.InValid(input);
        if(!Regex.IsMatch(input, regexValidationPhone))
            return Errors.General.InValid(input);
        return new Phone(input);

    }
}