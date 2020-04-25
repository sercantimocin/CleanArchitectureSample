using Common.Static;
using FluentValidation;

namespace Application.Checkout.Command
{
    public class AddProductToBasketRequestValidator : AbstractValidator<AddProductToBasketRequest>
    {
        public AddProductToBasketRequestValidator()
        {
            RuleFor(x => x.BasketId).NotEmpty().WithMessage(Errors.NotEmpty("BasketId"));
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(Errors.NotEmpty("ProducId"));
            RuleFor(x => x.Count).NotEmpty().WithMessage(Errors.NotEmpty("Count"));
            RuleFor(x => x.Count).GreaterThan(0).WithMessage(Errors.MustBeGreater("Count", 0));
        }
    }
}
