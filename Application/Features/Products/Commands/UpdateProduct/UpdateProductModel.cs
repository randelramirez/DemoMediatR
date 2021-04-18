namespace Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductModel
    {
        public string Name { get; init; }

        public double Price { get; init; }
    }
}