using System;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}