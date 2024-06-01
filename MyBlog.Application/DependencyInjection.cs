using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Validators;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace MyBlog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });

        return services;
    }
}
