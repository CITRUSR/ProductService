using MediatR;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Product.Commands.Create;

public class CreateCommandHandler : BaseHandler, IRequestHandler<CreateCommand, Guid>
{
    public CreateCommandHandler(IProductDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Product
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Category = request.Category,
        };

        await DbContext.Products.AddAsync(product,cancellationToken);
        
        await DbContext.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}