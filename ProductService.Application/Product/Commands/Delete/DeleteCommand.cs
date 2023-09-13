using MediatR;

namespace ProductService.Application.Product.Commands.Delete;

public class DeleteCommand : IRequest
{
    public Guid Id { get; set; }
}