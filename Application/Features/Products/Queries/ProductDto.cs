using System;

namespace Application.Features.Products.Queries
{
    public record ProductDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public double Price { get; init; }
    }
}