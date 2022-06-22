using Microsoft.AspNetCore.Mvc;
using Serilog;
using MediatR;
using ProductRegistration.Application.Commands.V1.Products;
using AutoMapper;
using ProductRegistration.Application.Events.Products;

namespace ProductRegistration.Api.Controllers.V1.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(ILogger logger,
                              IMediator mediator,
                              IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost(Name = "PostProduct"), MapToApiVersion("1.0")]
    public async Task<ActionResult<ProductResponse>> PostProduct([FromQuery] ProductRequest product)
    {
        var valueMapper = _mapper.Map<ProductNotification>(product);
        await _mediator.Publish(valueMapper);
        var result = await _mediator.Send(product);
        return Ok(result);
    }

    [HttpPost(Name = "PostProductv2"), MapToApiVersion("2.0")]
    public Task<ProductResponse> PostProductVersion([FromQuery] ProductRequest idProduct) =>
        _mediator.Send(idProduct);
}
