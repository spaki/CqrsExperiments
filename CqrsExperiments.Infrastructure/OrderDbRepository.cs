using CqrsExperiments.Domain.Interfaces;
using CqrsExperiments.Domain.Models;
using System.Diagnostics;

namespace CqrsExperiments.Infrastructure
{
    public class OrderDbRepository : IOrderDbRepository
    {
        static List<Order> orders = new List<Order>();

        public Order[] List(string? filter) 
            => orders
            .Where(e =>
                filter == null 
                || e.CustomerEmail.Contains(filter)
                || e.Number.Contains(filter)
                || e.DeliveryAddress.Contains(filter)
            )
            .ToArray();

        public void Save(Order entity)
        {
            orders.Add(entity);
            Debug.WriteLine($"Db Repository: Order {entity.Number} added to {entity.CustomerEmail}");
        }
    }
}
