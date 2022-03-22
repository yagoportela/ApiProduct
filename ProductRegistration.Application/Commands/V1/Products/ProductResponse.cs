using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.Products
{
    public class ProductResponse
    {
        public ProductDto? product { get; set; }
    }
} 