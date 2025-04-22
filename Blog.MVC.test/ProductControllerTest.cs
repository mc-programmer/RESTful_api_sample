using Blog.mvc.Controllers;
using Blog.mvc.Models;
using Blog.mvc.Models.MoqData;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Blog.MVC.test;

public class ProductControllerTest
{
    [Fact]
    public void Index_Test()
    {
        // arrange
        var products = MoqData.GetProducts();

        var moq = new Mock<IProductRepository>();

        moq.Setup(x => x.GetAll()).Returns(products);

        ProductController productController = new(moq.Object);

        // act
        var result = productController.Index();
        var viewResult = result as ViewResult;

        // assert
        Assert.IsType<ViewResult>(result);
        Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult?.ViewData.Model ?? null);
    }

    [Theory]
    [InlineData(1 , 0)]
    public void Details_test(int id , int inValidId)
    {
        // arrange
        var moqData = new MoqData();

        var moq = new Mock<IProductRepository>();

        moq.Setup(x => x.GetById(id)).Returns();

        ProductController productController = new(moq.Object);

        //act
        
    }
}