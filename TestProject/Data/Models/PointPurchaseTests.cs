using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.Data.Models
{
    [TestClass]
    public class PointPurchaseTests
    {
        private MockRepository mockRepository;

        private Mock<Ship> mockShip;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockShip = this.mockRepository.Create<Ship>();
        }

        private PointPurchase CreatePointPurchase()
        {
            Ship ship = new Healer { Length = 4 };
            PointPurchase pointPurchase = new PointPurchase(ship);
            return pointPurchase;
        }

        [TestMethod]
        public void CalculateTotalPrice_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pointPurchase = this.CreatePointPurchase();

            Assert.AreEqual(pointPurchase.CalculateTotalPrice(), 150);
        }
    }
}
