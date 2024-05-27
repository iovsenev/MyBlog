using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Application.Helpers;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace MyBlog.Application.Validators
{
    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(
            ActionExecutingContext context,
            ValidationProblemDetails? validationProblemDetails)
        {
            if (validationProblemDetails is null)
                return new BadRequestObjectResult("Wrong something");

            var errors = validationProblemDetails.Errors.ToDictionary();

            var envelope = RequestFormat.Error(errors);

            return new BadRequestObjectResult(envelope);
        }
    }
}
