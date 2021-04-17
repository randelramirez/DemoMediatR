using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductsService service;

        public CreateProductCommandHandler(IProductsService service) =>
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createProductCommandResponse = new CreateProductCommandResponse();

            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createProductCommandResponse.Success = false;
                createProductCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            
            if (createProductCommandResponse.Success)
            {
                var product = new Product() { Name = request.Model.Name, Price = request.Model.Price};
                await this.service.AddAsync(product);

                createProductCommandResponse.Product = new CreateProductDto()
                {
                    Id = product.Id, 
                    Name = product.Name, 
                    Price = product.Price
                };
            }

            return createProductCommandResponse;
        }
    }
}
