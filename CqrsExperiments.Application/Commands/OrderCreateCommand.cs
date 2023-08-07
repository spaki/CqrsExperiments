using CqrsExperiments.Application.Results;
using MediatR;

namespace CqrsExperiments.Application.Commands
{
    public class OrderCreateCommand : IRequest<OrderResult>
    {
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
    }
}
