using MediatR;

namespace ProductRegistration.Application.Events.Products;

public class ProductNotification : INotification
{
    public string? NameProduct { get; set; }
}
    