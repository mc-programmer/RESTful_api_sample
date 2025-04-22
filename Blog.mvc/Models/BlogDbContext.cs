using Microsoft.EntityFrameworkCore;

namespace Blog.mvc.Models;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}