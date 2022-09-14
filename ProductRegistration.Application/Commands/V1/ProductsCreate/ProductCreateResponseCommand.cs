using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.ProductsCreate
{
    public class ProductCreateResponseCommand
    {
        public ProductDto? product { get; set; }
    }
} 