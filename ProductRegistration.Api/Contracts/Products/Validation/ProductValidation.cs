using FluentValidation;

namespace ProductRegistration.Api.Contracts.Products.Validations;

public class ProductValidation : AbstractValidator<ProductsRequest>
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
