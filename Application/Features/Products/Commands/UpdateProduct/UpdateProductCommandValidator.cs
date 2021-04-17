using FluentValidation;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage($"{nameof(UpdateProductCommand.Price)} must have value greater than 0");
        }
    }
}