using CqrsExperiments.Application.Events;
using CqrsExperiments.Application.Interfaces;
using MediatR;

namespace CqrsExperiments.Application.Handlers
{
    public class MailHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly IMailService mailService;

        public MailHandler(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => mailService.Send(notification));
        }
    }
}
