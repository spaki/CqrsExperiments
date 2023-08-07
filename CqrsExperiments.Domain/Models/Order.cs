namespace CqrsExperiments.Domain.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            Number = Id.ToString("N");
            CreatedAtUtc = DateTime.UtcNow;
        }

        public Order(string customerEmail, string deliveryAddress, decimal totalPurchaseAmount) : this() 
        {
            CustomerEmail = customerEmail;
            DeliveryAddress = deliveryAddress;
            TotalPurchaseAmount = totalPurchaseAmount;
        }

        public virtual Guid Id { get; set; }
        public virtual string Number { get; set; }
        public virtual string CustomerEmail { get; set; }
        public virtual string DeliveryAddress { get; set; }
        public virtual decimal TotalPurchaseAmount { get; set; }
        public virtual DateTime CreatedAtUtc { get; set; }
    }
}
