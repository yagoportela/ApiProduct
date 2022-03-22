using Microsoft.AspNetCore.Mvc;
using Serilog;
using MediatR;
using ProductRegistration.Application.Commands.V1.Products;

namespace ProductRegistration.Api.Controllers.V1.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;

    public ProductsController(ILogger logger,
                              IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "PostProduct"), MapToApiVersion("1.0")]
    public ActionResult<ProductResponse> PostProduct([FromQuery] ProductRequest product) =>
        Ok(_mediator.Send(product));

    [HttpPost(Name = "PostProductv2"), MapToApiVersion("2.0")]
    public Task<ProductResponse> PostProductVersion([FromQuery] ProductRequest idProduct) =>
        _mediator.Send(idProduct);
}
