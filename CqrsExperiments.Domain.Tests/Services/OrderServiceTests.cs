using CqrsExperiments.Domain.Interfaces;
using CqrsExperiments.Domain.Models;
using CqrsExperiments.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CqrsExperiments.Domain.Tests.Services
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService orderService;

        [TestInitialize]
        public void Setup()
        {
            var orderDbRepositoryMock = new Mock<IOrderDbRepository>();
            orderService = new OrderService(orderDbRepositoryMock.Object);
        }

        [TestMethod]
        public async Task ShouldReturnSavedOrder()
        {
            var entity = new Order("mail@provider.com", "Delivery Address 007", 10);
            orderService.Save(entity);

            Assert.IsNotNull(entity.Number, $"Should Return Saved Order");
        }
    }
}
