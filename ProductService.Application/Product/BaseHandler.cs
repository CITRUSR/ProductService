using ProductService.Application.Interfaces;

namespace ProductService.Application.Product;

public class BaseHandler
{
    protected IProductDbContext DbContext;

    public BaseHandler(IProductDbContext dbContext)
    {
        DbContext = dbContext;
    }
}