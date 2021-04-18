using System;

namespace Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductDto (Guid Id, string Name, double Price);
}