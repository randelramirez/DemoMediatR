using System;
using Application.Responses;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandResponse : BaseResponse
    {
        public UpdateProductCommandResponse() => Product = new UpdateProductDto(Guid.Empty, string.Empty, default);

        public bool Exists { get; set; } = true;

        public UpdateProductDto Product { get; set; }
    }
}