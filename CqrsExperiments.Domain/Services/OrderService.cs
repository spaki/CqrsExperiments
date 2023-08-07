using CqrsExperiments.Domain.Interfaces;
using CqrsExperiments.Domain.Models;

namespace CqrsExperiments.Domain.Services
{

    public class OrderService : IOrderService
    {
        private readonly IOrderDbRepository orderDbRepository;

        public OrderService(IOrderDbRepository orderDbRepository)
        {
            this.orderDbRepository = orderDbRepository;
        }

        public Order[] List(string? filter) => orderDbRepository.List(filter);

        public void Save(Order entity) => orderDbRepository.Save(entity);
    }
}
