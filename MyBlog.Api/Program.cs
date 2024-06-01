using FluentValidation;
using MyBlog.Application;
using MyBlog.Persistence;
using MyBlog.Persistence.Repositories.Articles.Create;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
