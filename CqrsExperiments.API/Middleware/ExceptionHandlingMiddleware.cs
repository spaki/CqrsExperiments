using CqrsExperiments.Application.Exceptions;

namespace CqrsExperiments.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlingMiddleware> log;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> log)
        {
            this.next = next;
            this.log = log;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException vex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { Errors = vex.Errors });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
