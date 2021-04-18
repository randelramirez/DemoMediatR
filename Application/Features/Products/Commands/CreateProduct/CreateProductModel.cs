namespace Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductModel
    {
        public string Name { get; init; }

        public double Price { get; init; }
    }
}