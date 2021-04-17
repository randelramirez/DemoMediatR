using Application.Responses;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandResponse : BaseResponse
    {
        public UpdateProductCommandResponse() : base()
        {
            
        }

        public bool Exists { get; set; } = true;

        public UpdateProductDto Product { get; set; }
    }
}