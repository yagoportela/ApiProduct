using FluentValidation;
using MediatR;

namespace ProductRegistration.Application.Commands.V1.ProductsCreate;
public class ProductCreateRequestCommand : IRequest<ProductCreateResponseCommand>
{
    public string? NameProduct { get; set; }
}