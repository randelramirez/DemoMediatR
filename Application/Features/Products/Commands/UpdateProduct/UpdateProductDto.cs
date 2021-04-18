using System;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductDto(Guid Id, string Name, double Price);
}