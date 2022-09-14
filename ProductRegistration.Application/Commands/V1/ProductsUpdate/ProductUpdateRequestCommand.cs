using MediatR;

namespace ProductRegistration.Application.Commands.V1.ProductsUpdate;
public class ProductUpdateRequestCommand: IRequest<ProductUpdateResponseCommand>
{
    public string? NameProduct { get; set; }
}