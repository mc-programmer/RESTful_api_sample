using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Blog.api.Controllers.V2;

//[ApiVersion(1, Deprecated = true)]
[ApiController]
[ApiVersion(2)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ArticleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("hello");
    }
}