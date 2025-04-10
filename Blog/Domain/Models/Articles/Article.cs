using Blog.api.Domain.Models.Common;

namespace Blog.api.Domain.Models.Articles;

public class Article : BaseEntity
{
    public string? Title { get; set; }
}