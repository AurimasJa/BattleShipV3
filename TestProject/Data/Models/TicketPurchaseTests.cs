using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.Data.Models
{
    [TestClass]
    public class TicketPurchaseTests
    {
        private MockRepository mockRepository;

        private Mock<Ship> mockShip;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockShip = this.mockRepository.Create<Ship>();
        }

        private TicketPurchase CreateTicketPurchase()
        {
            Ship ship = new Healer { Length = 4 };
            TicketPurchase ticketPurchase = new TicketPurchase(ship);
            return ticketPurchase;
        }

        [TestMethod]
        public void CalculateTotalPrice_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var ticketPurchase = this.CreateTicketPurchase();

            Assert.AreEqual(ticketPurchase.CalculateTotalPrice(), 1);
        }

      /*  [TestMethod]
        public void CalculateTotalPrice_StateUnderTest_NotExpectedBehavior()
        {
            // Arrange
            var ticketPurchase = this.CreateTicketPurchase();

            Assert.AreNotEqual(ticketPurchase.CalculateTotalPrice(), 2);
        }*/
    }
}
