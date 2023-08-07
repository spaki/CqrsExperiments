using CqrsExperiments.Application.Events;
using CqrsExperiments.Application.Interfaces;
using MediatR;

namespace CqrsExperiments.Application.Handlers
{
    public class TmsHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly ITmsApiClient tmsApiClient;

        public TmsHandler(ITmsApiClient tmsApiClient)
        {
            this.tmsApiClient = tmsApiClient;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => tmsApiClient.Post(notification));
        }
    }
}
