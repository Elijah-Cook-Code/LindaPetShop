using FluentValidation;

namespace LindasPetShop
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(d => d.Price)
                .GreaterThan(0).WithMessage("Price must be a positive number.");

            RuleFor(d => d.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be a positive number.");

            RuleFor(d => d.Description)
                .Length(10, int.MaxValue).When(d => !string.IsNullOrEmpty(d.Description))
                .WithMessage("If description is provided, it must be at least 10 characters long.");
        }
    }
}
