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

        public Order[] List() => orderDbRepository.List();

        public void Save(Order entity) => orderDbRepository.Save(entity);
    }
}
