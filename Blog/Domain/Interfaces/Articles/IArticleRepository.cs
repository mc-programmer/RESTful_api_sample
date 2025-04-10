using Blog.api.Domain.Interfaces.Common;
using Blog.api.Domain.Models.Articles;

namespace Blog.api.Domain.Interfaces.Articles;

public interface IArticleRepository : IRepository<Article, int>;