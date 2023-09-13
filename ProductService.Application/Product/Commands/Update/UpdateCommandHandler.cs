using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Product.Commands.Update;

public class UpdateCommandHandler : BaseHandler, IRequestHandler<UpdateCommand, Domain.Product>
{
    public UpdateCommandHandler(IProductDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Domain.Product> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product != null)
        {
            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            DbContext.Products.Update(product);
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return product;
    }
}