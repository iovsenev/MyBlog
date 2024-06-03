using MyBlog.Application.Helpers;

namespace MyBlog.Api.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler (RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            var exName = e.GetType().Name;
            var error = new Dictionary<string, string[]>();
            error.Add(exName,new[] { e.Message });
            var envelope = ResponseFormat.Error(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(envelope);
        }
    }
}
