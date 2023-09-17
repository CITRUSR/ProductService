using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Product.Commands.Create;
using ProductService.Application.Product.Commands.Delete;
using ProductService.Application.Product.Commands.Update;
using ProductService.Application.Product.Queries.Get;
using ProductService.Application.Product.Queries.GetAll;
using ProductService.Domain;
using ProductService.Presentation.Models;

namespace ProductService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// GetAllProducts
    /// </summary>
    /// <returns>Product list</returns>
    /// <return code="200">Success</return>
    [HttpGet]
    [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProducts()
    {
        var request = new GetAllQuery();
        var data = await _mediator.Send(request);
        return Ok(data);
    }

    /// <summary>
    /// GetProductById
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product by id</returns>
    /// <return code="200">Success</return>
    [HttpGet]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var request = new GetQuery { Id = id };
        var data = await _mediator.Send(request);
        return Ok(data);
    }

    /// <summary>
    /// CreateProduct
    /// </summary>
    /// <param name="model"></param>
    /// <returns>New product id</returns>
    /// <return code="200">Success</return>
    /// <return code="400">Validation error</return>
    /// <return code="401">Unauthorized</return>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<ValidationFailure>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductDTO model)
    {
        var command = new CreateCommand
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            Category = model.Category,
        };

        var product = await _mediator.Send(command);

        return Ok(product);
    }

    /// <summary>
    /// DeleteProductById
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <return code="204">Success</return>
    /// <return code="401">Unauthorized</return>
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var command = new DeleteCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// UpdateProduct
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Updated product</returns>
    /// <return code="200">Success</return>
    /// <return code="400">Validation error</return>
    [HttpPut]
    [Authorize]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<ValidationFailure>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody]UpdateProductDTO model)
    {
        var command = new UpdateCommand
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Category = model.Category,
        };
        var product = await _mediator.Send(command);

        return Ok(product);
    }
}