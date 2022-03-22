using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductRegistration.Domain.Dtos;

namespace ProductRegistration.Application.Commands.V1.Products
{
    public class ProductsHeader : IRequestHandler<ProductRequest, ProductResponse>
    {
        private readonly IMapper _mapper;

        public ProductsHeader(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            var productDto = _mapper.Map<ProductDto>(request);
            return Task.Run(() => new ProductResponse
            {
                product = productDto
            });
        }
    }
}