using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.Application.Interfaces;

public interface IProductDbContext
{
    public DbSet<Domain.Product> Products { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}