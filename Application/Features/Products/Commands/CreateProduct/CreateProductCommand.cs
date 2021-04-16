using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }

   
}