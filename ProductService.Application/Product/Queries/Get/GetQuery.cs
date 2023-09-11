using MediatR;

namespace ProductService.Application.Product.Queries.Get;

public class GetQuery : IRequest<Domain.Product>
{
    public Guid Id { get; set; }
}