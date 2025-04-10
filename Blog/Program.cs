using Blog.api.Application.Services.Implementations;
using Blog.api.Application.Services.Interfaces;
using Blog.api.Domain.Interfaces.Articles;
using Blog.api.Infrastructure.Repositories.Articles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

#region Dependency injection

#region Repositories

builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

#endregion

#region Services

builder.Services.AddTransient<IArticleService, ArticleService>();

#endregion

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
