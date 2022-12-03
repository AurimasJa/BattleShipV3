using BattleShipV3.Client.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.Pages
{
    [TestClass]
    public class CounterTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Counter CreateCounter()
        {
            return new Counter();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var counter = this.CreateCounter();

            // Act
            counter.IncrementCount();

            // Assert
            Assert.AreEqual(counter.currentCount, 1);
            //Assert.Fail();
            //this.mockRepository.VerifyAll();
        }
    }
}
