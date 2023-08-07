using CqrsExperiments.Application.Commands;
using CqrsExperiments.Application.Queries;
using CqrsExperiments.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsExperiments.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResult>> Get([FromQuery] OrderByFilterQuery query)
            => await mediator.Send(query).ConfigureAwait(false);

        [HttpPost]
        public async Task<OrderResult> CreateAsync(OrderCreateCommand command) 
            => await mediator.Send(command).ConfigureAwait(false);
    }
}