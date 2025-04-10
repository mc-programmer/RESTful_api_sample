using Blog.api.Domain.Interfaces.Articles;
using Blog.api.Domain.Models.Articles;
using Blog.api.Infrastructure.Repositories.Common;

namespace Blog.api.Infrastructure.Repositories.Articles;

public class ArticleRepository : InMemoryRepository<Article, int>, IArticleRepository
{
    public ArticleRepository() : this(GetSeedData()) { }

    public ArticleRepository(List<Article> initialData) : base(initialData) { }

    private static List<Article> GetSeedData()
    {
        return new List<Article>
        {
            new Article { Id = 1, Title = "first article" },
            new Article { Id = 2, Title = "second article"}
        };
    }
}