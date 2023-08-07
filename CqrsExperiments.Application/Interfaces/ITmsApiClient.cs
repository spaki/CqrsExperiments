using CqrsExperiments.Application.Events;

namespace CqrsExperiments.Application.Interfaces
{
    public interface ITmsApiClient
    {
        void Post(OrderCreatedEvent order);
    }
}
