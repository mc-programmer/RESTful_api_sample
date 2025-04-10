using Blog.api.Application.Services.Interfaces;
using Blog.api.Domain.DTOs.Articles.Articles;
using Microsoft.AspNetCore.Mvc;

namespace Blog.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController(IArticleService articleService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var result = articleService.GetAll();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateArticleDto model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await articleService.CreateAsync(model);

        if (!result)
        {
            return BadRequest();
        }

        return Created();
    }
}