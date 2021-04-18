using System;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public double Price { get; init; }
    }
}