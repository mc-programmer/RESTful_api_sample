using Blog.mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.mvc.Controllers;

public class HomeController(IProductRepository productRepository) : Controller
{
    public IActionResult Index()
        => View(productRepository.GetAll());

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Product model)
    {
        var result = productRepository.Add(model);

        return RedirectToAction(nameof(Index), "Home");
    }

    [HttpPost]
    public IActionResult Remove(int id)
    {
        productRepository.Remove(id);

        return RedirectToAction(nameof(Index), "Home");
    }
}