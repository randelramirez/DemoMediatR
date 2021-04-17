using System;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public readonly Guid Id;
        public readonly UpdateProductModel Model;

        public UpdateProductCommand(Guid id, UpdateProductModel model)
        {
            Id = id;
            Model = model;
        }
    }

    public class UpdateProductModel
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}