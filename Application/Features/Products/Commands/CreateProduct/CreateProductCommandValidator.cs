using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Model.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(p => p.Model.Price)
                .GreaterThan(0)
                .WithMessage($"{nameof(CreateProductCommand.Model.Price)} must have value greater than 0");
        }
    }
}