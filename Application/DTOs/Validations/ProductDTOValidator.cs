using FluentValidation;

namespace Application.DTOs.Validations
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("CodErp deve ser informado");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name deve ser informado");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price deve ser maior que zero");
        }
    }
}
