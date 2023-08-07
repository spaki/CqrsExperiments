using CqrsExperiments.Domain.Models;

namespace CqrsExperiments.Domain.Interfaces
{
    public interface IOrderService
    {
        void Save(Order entity);
        Order[] List();
    }
}
