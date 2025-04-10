using Blog.api.Domain.DTOs.Articles.Articles;

namespace Blog.api.Application.Services.Interfaces;

public interface IArticleService
{
    IEnumerable<ArticleDetailsForListDto> GetAll();
    Task<bool> CreateAsync(CreateArticleDto model);
}