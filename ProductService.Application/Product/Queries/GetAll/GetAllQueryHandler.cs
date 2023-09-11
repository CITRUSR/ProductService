using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Product.Queries.GetAll;

public class GetAllQueryHandler : BaseHandler, IRequestHandler<GetAllQuery,List<Domain.Product>>
{
    public GetAllQueryHandler(IProductDbContext dbContext) : base(dbContext){}

    public async Task<List<Domain.Product>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await DbContext.Products.ToListAsync(cancellationToken);
    }
}