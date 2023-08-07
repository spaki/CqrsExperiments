using CqrsExperiments.Domain.Models;

namespace CqrsExperiments.Domain.Interfaces
{
    public interface IOrderDbRepository
    {
        void Save(Order entity);
        Order[] List();
    }
}
