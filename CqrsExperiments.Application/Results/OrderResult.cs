using CqrsExperiments.Domain.Models;

namespace CqrsExperiments.Application.Results
{
    public class OrderResult
    {
        public OrderResult(Order entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            CustomerEmail = entity.CustomerEmail;
            DeliveryAddress = entity.DeliveryAddress;
            TotalPurchaseAmount = entity.TotalPurchaseAmount;
            CreatedAtUtc = entity.CreatedAtUtc;
        }

        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
