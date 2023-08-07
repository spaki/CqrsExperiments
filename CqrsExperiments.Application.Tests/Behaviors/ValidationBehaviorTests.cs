using CqrsExperiments.Application.Behaviors;
using CqrsExperiments.Application.Commands;
using CqrsExperiments.Application.Exceptions;
using CqrsExperiments.Application.Results;
using CqrsExperiments.Application.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CqrsExperiments.Application.Tests.Behaviors
{
    [TestClass]
    public class ValidationBehaviorTests
    {
        private ValidationBehavior<OrderCreateCommand, OrderResult> validationBehavior;

        [TestInitialize]
        public void Setup()
        {
            var orderCreateValidator = new OrderCreateValidator();
            validationBehavior = new ValidationBehavior<OrderCreateCommand, OrderResult>(new[] { orderCreateValidator });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWithEmptyCustomerMail()
        {
            var command = new OrderCreateCommand { DeliveryAddress = "Delivery Address, 007", TotalPurchaseAmount = 10 };
            validationBehavior.Handle(command, default, default);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWithNegativeOrderAmount()
        {
            var command = new OrderCreateCommand { CustomerEmail = "customer@mail.com", DeliveryAddress = "Delivery Address, 007", TotalPurchaseAmount = -10 };
            validationBehavior.Handle(command, default, default);
        }
    }
}
