using Domain;
using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage($"{nameof(Product.Price)} must have value greater than 0");
        }
    }
}