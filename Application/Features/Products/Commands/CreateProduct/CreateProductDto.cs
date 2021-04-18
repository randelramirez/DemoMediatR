using System;

namespace Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public double Price { get; init; }
    }
}