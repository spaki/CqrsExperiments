using CqrsExperiments.Application.Events;
using CqrsExperiments.Application.Interfaces;
using System.Diagnostics;

namespace CqrsExperiments.Infrastructure
{
    public class TmsApiClient : ITmsApiClient
    {
        public void Post(OrderCreatedEvent order)
        {
            Debug.WriteLine($"TMS API Client: Order {order.Number} posted to {order.DeliveryAddress}");
        }
    }
}
