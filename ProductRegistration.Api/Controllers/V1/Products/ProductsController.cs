using Microsoft.AspNetCore.Mvc;
using Serilog;
using MediatR;
using AutoMapper;
using ProductRegistration.Application.Commands.V1.ProductsCreate;
using ProductRegistration.Api.Contracts.Products;
using ProductRegistration.Application.Commands.V1.ProductsUpdate;
using ProductRegistration.Application.Commands.V1.ProductsDelete;
using ProductRegistration.Application.Events.Products.UpdateHandler;
using ProductRegistration.Application.Events.Products.CreateHandler;
using ProductRegistration.Application.Events.Products.DeleteHandler;

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

    [HttpPost(Name = "CreateProduct"), MapToApiVersion("1.0")]
    public async Task<ActionResult<ProductCreateResponseCommand>> PostCreatedProduct([FromQuery] ProductsRequest product)
    {
        var valueMapperNotification = _mapper.Map<ProductNotificationCreate>(product);
        var valueMapperRequest = _mapper.Map<ProductCreateRequestCommand>(product);

        await _mediator.Publish(valueMapperNotification);
        var result = await _mediator.Send(valueMapperRequest);
        return Ok(result);
    }

    [HttpPost(Name = "UpdateProduct"), MapToApiVersion("1.0")]
    public async Task<ActionResult<ProductUpdateResponseCommand>> PostUpdateProduct([FromQuery] ProductsRequest product)
    {
        var valueMapperNotification = _mapper.Map<ProductNotificationUpdate>(product);
        var valueMapperRequest = _mapper.Map<ProductUpdateRequestCommand>(product);

        await _mediator.Publish(valueMapperNotification);
        var result = await _mediator.Send(valueMapperRequest);
        return Ok(result);
    }

    [HttpPost(Name = "DeleteProduct"), MapToApiVersion("1.0")]
    public async Task<ActionResult<ProductDeleteResponseCommand>> PostDeleteProduct([FromQuery] ProductsRequest product)
    {
        var valueMapperNotification = _mapper.Map<ProductNotificationDelete>(product);
        var valueMapperRequest = _mapper.Map<ProductDeleteRequestCommand>(product);

        await _mediator.Publish(valueMapperNotification);
        var result = await _mediator.Send(valueMapperRequest);
        return Ok(result);
    }

    [HttpPost(Name = "PostProductv2"), MapToApiVersion("2.0")]
    public Task<object?> PostProductVersion([FromQuery] ProductsRequest idProduct) =>
        _mediator.Send(idProduct);
}
