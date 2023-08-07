using CqrsExperiments.API.Middleware;
using CqrsExperiments.Application.Behaviors;
using CqrsExperiments.Application.Handlers;
using CqrsExperiments.Application.Interfaces;
using CqrsExperiments.Domain.Interfaces;
using CqrsExperiments.Domain.Services;
using CqrsExperiments.Infrastructure;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// -> adding MediatR, Fluent and Internal services refs
var targetAssembly = typeof(OrderHandler).Assembly;
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(targetAssembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(targetAssembly);

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDbRepository, OrderDbRepository>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<ITmsApiClient, TmsApiClient>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// -> validations
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
