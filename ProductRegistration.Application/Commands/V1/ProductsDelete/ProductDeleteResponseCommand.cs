using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.ProductsDelete;

public class ProductDeleteResponseCommand
{
    public ProductDto? product { get; set; }
}
