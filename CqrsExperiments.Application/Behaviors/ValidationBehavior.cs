using CqrsExperiments.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace CqrsExperiments.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var conext = new ValidationContext<TRequest>(request);

            var errors = validators
                .Select(e => e.Validate(conext))
                .Where(e => !e.IsValid)
                .SelectMany(e => e.Errors)
                .Select(e => new ValidationError(
                    e.PropertyName,
                    e.ErrorMessage
                ))
                .ToArray()
                ;

            if (errors.Any())
                throw new Exceptions.ValidationException(errors);

            return next();
        }
    }
}
