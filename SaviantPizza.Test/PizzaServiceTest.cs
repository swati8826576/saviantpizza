using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaviantPizza.Business.Service;
using SaviantPizza.Repository.IRepository;

namespace SaviantPizza.Test
{

    [TestClass]
    public class PizzaTest
    {
        private readonly PizzaService _service;
        private readonly Mock<IPizzaDetailViewRepository> repository = new Mock<IPizzaDetailViewRepository>();
        private readonly Mock<IDisountRepository> discountRepository = new Mock<IDisountRepository>();


        public PizzaTest()
        {
            _service = new PizzaService(repository.Object);
        }

        [TestMethod]
        public void GetAllPizzaDetails_ReturnPizzaDetails_Test()
        {
            //arrange
            var expected = Setup.Setup.GetPizzaDetails();

            repository.Setup(e => e.GetAll()).Returns(expected);

            //Act
            var actual = _service.GetPizzaList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
