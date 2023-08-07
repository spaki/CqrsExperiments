using CqrsExperiments.Application.Commands;
using FluentValidation;

namespace CqrsExperiments.Application.Validators
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
    {
        public OrderCreateValidator()
        {
            RuleFor(e => e.CustomerEmail).NotEmpty();
            RuleFor(e => e.DeliveryAddress).NotEmpty();
            RuleFor(e => e.TotalPurchaseAmount).GreaterThan(0).WithMessage("Order should have a valid amount");
        }
    }
}
