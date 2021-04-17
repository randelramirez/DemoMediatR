using Application.Responses;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public CreateProductCommandResponse() =>
            Product = new CreateProductDto();
        
        public CreateProductDto Product { get; set; }
    }
}