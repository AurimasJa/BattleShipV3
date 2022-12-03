using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.Data.Models
{
    [TestClass]
    public class CashPurchaseTests
    {
        private MockRepository mockRepository;

        private Mock<Ship> mockShip;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockShip = this.mockRepository.Create<Ship>();
        }

        private CashPurchase CreateCashPurchase()
        {
            Ship ship = new Healer { Length = 4 };
            CashPurchase cashPurchase = new CashPurchase(ship);
            return cashPurchase;
        }

        [TestMethod]
        public void CalculateTotalPrice_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cashPurchase = this.CreateCashPurchase();

            Assert.AreEqual(cashPurchase.CalculateTotalPrice(), 1.99);

        }
    }
}
