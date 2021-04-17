using System;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}