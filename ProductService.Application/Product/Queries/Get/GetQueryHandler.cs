using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Product.Queries.Get;

public class GetQueryHandler : BaseHandler, IRequestHandler<GetQuery, Domain.Product>
{
    public GetQueryHandler(IProductDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Domain.Product> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        return await DbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}