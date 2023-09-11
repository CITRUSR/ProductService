using MediatR;

namespace ProductService.Application.Product.Queries.GetAll;

public class GetAllQuery : IRequest<List<Domain.Product>>
{
    
}