using FluentValidation;

namespace Application.DTOs.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("CodErp deve ser informado!");

            RuleFor(x => x.Document)
                .NotNull()
                .NotEmpty()
                .WithMessage("Document deve ser informado!");
        }
    }
}
