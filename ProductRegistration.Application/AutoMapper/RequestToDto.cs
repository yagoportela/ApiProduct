using AutoMapper;
using ProductRegistration.Application.Commands.V1.Products;
using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.AutoMapper;

public class RequestToDto : Profile
{
    public RequestToDto()
    {
        CreateMap<ProductRequest, ProductDto>()
            .ForMember(src => src.NameProduct, rc => rc.MapFrom(src => src.NameProduct));
    }
}
