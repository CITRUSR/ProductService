﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Product.Queries.Get;
using ProductService.Application.Product.Queries.GetAll;
using ProductService.Presentation.Models;

namespace ProductService.Presentation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var request = new GetAllQuery();
        var data = await _mediator.Send(request);
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var request = new GetQuery { Id = id };
        var data = await _mediator.Send(request);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDTO model)
    {
        return Ok();
    }
}