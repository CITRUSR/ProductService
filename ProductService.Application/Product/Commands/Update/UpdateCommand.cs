﻿using MediatR;

namespace ProductService.Application.Product.Commands.Update;

public class UpdateCommand : IRequest<Domain.Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}