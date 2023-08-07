using CqrsExperiments.Application.Events;
using CqrsExperiments.Application.Interfaces;
using System.Diagnostics;

namespace CqrsExperiments.Infrastructure
{
    public class MailService : IMailService
    {
        public void Send(OrderCreatedEvent order)
        {
            Debug.WriteLine($"Mail Service: Mail sent to {order.CustomerEmail} with Order {order.Number}");
        }
    }
}
