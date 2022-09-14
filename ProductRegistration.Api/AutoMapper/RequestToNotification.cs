using AutoMapper;
using ProductRegistration.Api.Contracts.Products;
using ProductRegistration.Application.Events.Products.CreateHandler;
using ProductRegistration.Application.Events.Products.DeleteHandler;
using ProductRegistration.Application.Events.Products.UpdateHandler;

namespace ProductRegistration.Api;

public class RequestToNotification : Profile
{
    public RequestToNotification()
    {
        CreateMap<ProductsRequest, ProductNotificationCreate>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));

        CreateMap<ProductsRequest, ProductNotificationUpdate>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));

        CreateMap<ProductsRequest, ProductNotificationDelete>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));
    }
}
