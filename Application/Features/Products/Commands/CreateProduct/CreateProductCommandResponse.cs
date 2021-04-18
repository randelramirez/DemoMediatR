using System;
using Application.Responses;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public CreateProductCommandResponse() =>
            Product = new CreateProductDto(Guid.Empty, string.Empty, default);
        
        public CreateProductDto Product { get; set; }
    }
}