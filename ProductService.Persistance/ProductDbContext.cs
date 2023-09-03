using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain;

namespace ProductService.Persistance;

public class ProductDbContext : DbContext, IProductDbContext
{
    public DbSet<Product> Products { get; set; }
    
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

}