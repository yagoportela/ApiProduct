using AutoMapper;
using ProductRegistration.Application.Commands.V1.Products;
using ProductRegistration.Application.Events.Products;

namespace ProductRegistration.Api.AutoMapper;

public class RequestToNotification : Profile
{
    public RequestToNotification()
    {
        CreateMap<ProductRequest, ProductNotification>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));
    }
}
