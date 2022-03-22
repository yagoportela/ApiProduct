using FluentValidation;
using MediatR;

namespace ProductRegistration.Application.Commands.V1.Products;
public class ProductRequest : IRequest<ProductResponse>
{
    public string? NameProduct { get; set; }
}

public class ProductValidation : AbstractValidator<ProductRequest>
{
    public ProductValidation()
    {
        ValidateNameProduct();
    }

    public void ValidateNameProduct() =>
        RuleFor(x => x.NameProduct)
            .NotEmpty()
            .NotNull();
}