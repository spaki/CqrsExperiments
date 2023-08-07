using CqrsExperiments.Application.Commands;
using CqrsExperiments.Application.Results;
using CqrsExperiments.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsExperiments.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IOrderDbRepository orderDbRepository;

        public OrderController(IMediator mediator, IOrderDbRepository orderDbRepository)
        {
            this.mediator = mediator;
            this.orderDbRepository = orderDbRepository;
        }

        [HttpGet]
        public IEnumerable<OrderResult> Get() 
            => orderDbRepository.List().Select(e => new OrderResult(e));

        [HttpPost]
        public async Task<OrderResult> CreateAsync(OrderCreateCommand command) 
            => await mediator.Send(command).ConfigureAwait(false);
    }
}