using System.ComponentModel.DataAnnotations;

namespace Blog.api.Domain.DTOs.Articles.Articles;

public class CreateArticleDto
{
    [Required]
    public string? Title { get; set; }
}