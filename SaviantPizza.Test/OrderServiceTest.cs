using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaviantPizza.Business.Helper;
using SaviantPizza.Business.Service;
using SaviantPizza.Repository.IRepository;
using SaviantPizza.Test.Setup;
using System.Linq;

namespace SaviantPizza.UnitTest
{
    [TestClass]
    public class OrderServiceTest
    {

        private readonly OrderService _service;
        private readonly Mock<IOrderRepository> repository = new Mock<IOrderRepository>();
        private readonly Mock<ILoggingHelper> logger = new Mock<ILoggingHelper>();


        public OrderServiceTest()
        {
            _service = new OrderService(repository.Object , logger.Object);
        }

        [TestMethod]
        public void PlaceOrder_Test_ReturnsTrue()
        {
            //arrange
            var OrderMadeByUser = Setup.GetOrderEntities();

            repository.Setup(e => e.Insert(OrderMadeByUser.FirstOrDefault()));

            //Act
            var actual = _service.SaveOrder(OrderMadeByUser);

            //assert 
            Assert.IsTrue(actual);
        }
    }
}
