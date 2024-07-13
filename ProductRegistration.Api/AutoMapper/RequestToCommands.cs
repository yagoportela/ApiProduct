using AutoMapper;
using ProductRegistration.Api.Contracts.Products;
using ProductRegistration.Application.Commands.V1.ProductsCreate;
using ProductRegistration.Application.Commands.V1.ProductsDelete;
using ProductRegistration.Application.Commands.V1.ProductsUpdate;

namespace ProductRegistration.Api;

public class RequestToCommands : Profile
{
    public RequestToCommands()
    {
        CreateMap<ProductsRequest, ProductCreateRequestCommand>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));

        CreateMap<ProductsRequest, ProductUpdateRequestCommand>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));

        CreateMap<ProductsRequest, ProductDeleteRequestCommand>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));
    }
}
