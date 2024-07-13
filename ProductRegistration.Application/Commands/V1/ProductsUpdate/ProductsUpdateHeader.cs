using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.ProductsUpdate;

public class ProductsUpdateHeader : IRequestHandler<ProductUpdateRequestCommand, ProductUpdateResponseCommand>
{
    private readonly IMapper _mapper;

    public ProductsUpdateHeader(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<ProductUpdateResponseCommand> Handle(ProductUpdateRequestCommand request, CancellationToken cancellationToken)
    {
        var productDto = _mapper.Map<ProductDto>(request);
        return Task.Run(() => new ProductUpdateResponseCommand
        {
            product = productDto
        });
    }
}
