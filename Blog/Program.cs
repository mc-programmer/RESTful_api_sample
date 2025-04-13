using Asp.Versioning;
using Blog.api.Application.Services.Implementations;
using Blog.api.Application.Services.Interfaces;
using Blog.api.Domain.Interfaces.Articles;
using Blog.api.Infrastructure.Repositories.Articles;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1,0);
    options.ReportApiVersions = true;
});

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
    app.MapScalarApiReference(options =>
    {
        options
        .WithTheme(ScalarTheme.Mars)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.RestSharp);

        //.WithTitle("alipour")
        //.WithApiKeyAuthentication(keyOptions => keyOptions.Token = "apiToken");
        //.WithPreferredScheme("ApiKey");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
