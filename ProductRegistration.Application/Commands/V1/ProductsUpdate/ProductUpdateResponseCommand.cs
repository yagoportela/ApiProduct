using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.ProductsUpdate;

public class ProductUpdateResponseCommand
{
    public ProductDto? product { get; set; }
}
