using Blog.api.Application.Services.Interfaces;
using Blog.api.Domain.DTOs.Articles.Articles;
using Blog.api.Domain.Interfaces.Articles;
using Blog.api.Domain.Models.Articles;

namespace Blog.api.Application.Services.Implementations;

public class ArticleService(IArticleRepository articleRepository) : IArticleService
{
    public async Task<bool> CreateAsync(CreateArticleDto model)
    {
        var article = new Article()
        {
            Title = model.Title
        };

        await articleRepository.AddAsync(article);

        return true;
    }

    public IEnumerable<ArticleDetailsForListDto> GetAll()
    {
        var result = articleRepository.GetAll().Select(x => new ArticleDetailsForListDto
        {
            Id  = x.Id,
            Title = x.Title
        });

        return result;
    }
}