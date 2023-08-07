using CqrsExperiments.Application.Commands;
using CqrsExperiments.Application.Events;
using CqrsExperiments.Application.Results;
using CqrsExperiments.Domain.Interfaces;
using CqrsExperiments.Domain.Models;
using MediatR;

namespace CqrsExperiments.Application.Handlers
{
    public class OrderHandler : IRequestHandler<OrderCreateCommand, OrderResult>
    {
        protected readonly IOrderService orderService;
        protected readonly IMediator mediator;

        public OrderHandler(IOrderService orderService, IMediator mediator)
        {
            this.orderService = orderService;
            this.mediator = mediator;
        }

        public async Task<OrderResult> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order(request.CustomerEmail, request.DeliveryAddress, request.TotalPurchaseAmount);
            orderService.Save(entity);

            var entityEvent = new OrderCreatedEvent(entity);
            await mediator.Publish(entityEvent);

            var result = new OrderResult(entity);
            return result;
        }
    }
}
