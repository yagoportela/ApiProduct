using MediatR;

namespace ProductRegistration.Application.Commands.V1.ProductsDelete;
public class ProductDeleteRequestCommand: IRequest<ProductDeleteResponseCommand>
{
    public string? NameProduct { get; set; }
}