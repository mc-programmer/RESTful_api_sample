namespace Blog.mvc.Models.MoqData;

public static class MoqData
{
    public static IEnumerable<Product> GetProducts()
    {
        List<Product> products = new List<Product>()
        {
            new Product {Id = 1 , Title = "asd"},
            new Product {Id = 2 , Title = "sdf"},
            new Product {Id = 3 , Title = "qwe"}
        };

        return products;
    }
}
