using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler :  IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductsService service;

        public UpdateProductCommandHandler(IProductsService service) => 
            this.service = service ?? throw  new  ArgumentNullException(nameof(service));
        
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProductCommandResponse = new UpdateProductCommandResponse();

            var exists = await this.service.IsExistingAsync(request.Id);
            if (!exists)
            {
                updateProductCommandResponse.Exists = false;
                return updateProductCommandResponse;
            }
            
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
            {
                updateProductCommandResponse.Success = false;
                updateProductCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            
            if (updateProductCommandResponse.Success)
            {
                var product = new Product()
                {
                    Id = request.Id, 
                    Name = request.Model.Name, 
                    Price = request.Model.Price
                };
                await this.service.UpdateAsync(product);

                updateProductCommandResponse.Product = new UpdateProductDto()
                {
                    Id = product.Id, 
                    Name = product.Name, 
                    Price = product.Price
                };
            }
            
            return updateProductCommandResponse;
        }
    }
}
