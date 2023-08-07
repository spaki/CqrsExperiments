using CqrsExperiments.Application.Events;

namespace CqrsExperiments.Application.Interfaces
{
    public interface IMailService
    {
        void Send(OrderCreatedEvent order);
    }
}
