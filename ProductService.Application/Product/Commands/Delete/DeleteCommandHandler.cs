using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Product.Commands.Delete;

public class DeleteCommandHandler : BaseHandler, IRequestHandler<DeleteCommand>
{
    public DeleteCommandHandler(IProductDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var product = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        DbContext.Products.Remove(product);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}