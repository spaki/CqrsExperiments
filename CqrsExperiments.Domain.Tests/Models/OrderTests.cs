using CqrsExperiments.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CqrsExperiments.Domain.Tests.Models
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void ShouldGenerateOrderNumber()
        {
            var entity = new Order("mail@provider.com", "Delivery Address 007", 10);
            Assert.IsNotNull(entity.Number, $"Should Generate Order Number");
        }
    }
}
