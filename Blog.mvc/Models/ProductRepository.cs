namespace Blog.mvc.Models;

public interface IProductRepository
{
    Product Add(Product product);
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Remove(int id);
}

public class ProductRepository(BlogDbContext context) : IProductRepository
{
    public Product Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();

        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        return context.Products.ToList();
    }

    public Product GetById(int id)
    {
        return context.Products.FirstOrDefault(x => x.Id == id) ?? new();
    }

    public void Remove(int id)
    {
        var product = context.Products.FirstOrDefault();

        if (product is null) return;

        context.Products.Remove(product);
        context.SaveChanges();
    }
}