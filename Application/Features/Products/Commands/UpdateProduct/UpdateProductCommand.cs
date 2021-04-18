using System;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public readonly Guid Id;
        public readonly UpdateProductModel Model;

        public UpdateProductCommand(Guid id, UpdateProductModel model) => (Id, Model) = (id, model);
    }
}