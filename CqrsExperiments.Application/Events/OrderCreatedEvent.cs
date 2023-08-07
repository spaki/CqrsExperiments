using CqrsExperiments.Domain.Models;
using MediatR;

namespace CqrsExperiments.Application.Events
{
    public class OrderCreatedEvent : INotification
    {
        public OrderCreatedEvent(Order entity)
        {
            Number = entity.Number;
            CustomerEmail = entity.CustomerEmail;
            DeliveryAddress = entity.DeliveryAddress;
            TotalPurchaseAmount = entity.TotalPurchaseAmount;
        }

        public string Number { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
    }
}
