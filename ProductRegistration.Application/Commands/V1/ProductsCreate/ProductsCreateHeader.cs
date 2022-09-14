using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.ProductsCreate;

public class ProductsCreateHeader : IRequestHandler<ProductCreateRequestCommand, ProductCreateResponseCommand>
{
    private readonly IMapper _mapper;

    public ProductsCreateHeader(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<ProductCreateResponseCommand> Handle(ProductCreateRequestCommand request, CancellationToken cancellationToken)
    {
        var productDto = _mapper.Map<ProductDto>(request);
        return Task.Run(() => new ProductCreateResponseCommand
        {
            product = productDto
        });
    }
}
