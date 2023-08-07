using CqrsExperiments.Application.Results;
using MediatR;

namespace CqrsExperiments.Application.Queries
{
    public class OrderByFilterQuery : IRequest<IEnumerable<OrderResult>>
    {
        public string? Filter { get; set; }
    }
}
