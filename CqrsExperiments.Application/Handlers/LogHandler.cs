using CqrsExperiments.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CqrsExperiments.Application.Handlers
{
    public class LogHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly ILogger<LogHandler> log;

        public LogHandler(ILogger<LogHandler> log)
        {
            this.log = log;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => log.LogInformation($"Order {notification.Number} created"));
        }
    }
}
