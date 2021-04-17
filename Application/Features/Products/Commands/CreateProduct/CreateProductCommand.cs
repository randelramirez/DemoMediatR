using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<CreateProductCommandResponse>
    {
        public readonly CreateProductModel Model;

        public CreateProductCommand(CreateProductModel model)
        {
            this.Model = model;
        }
    }
}