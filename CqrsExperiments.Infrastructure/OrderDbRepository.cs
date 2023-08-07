using CqrsExperiments.Domain.Interfaces;
using CqrsExperiments.Domain.Models;
using System.Diagnostics;

namespace CqrsExperiments.Infrastructure
{
    public class OrderDbRepository : IOrderDbRepository
    {
        static List<Order> orders = new List<Order>();

        public Order[] List() => orders.ToArray();

        public void Save(Order entity)
        {
            orders.Add(entity);
            Debug.WriteLine($"Db Repository: Order {entity.Number} added to {entity.CustomerEmail}");
        }
    }
}
