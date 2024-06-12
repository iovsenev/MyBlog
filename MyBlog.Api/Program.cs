using FluentValidation;
using MyBlog.Api.Middlewares;
using MyBlog.Application;
using MyBlog.Application.Services.Articles;
using MyBlog.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddValidatorsFromAssembly(typeof(CreateArticleRequestValidator).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
