using BattleShipV3.Client.DesignPatterns.Builder;
using BattleShipV3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.DesignPatterns.Builder
{
    [TestClass]
    public class BasicShipBuilderTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private BasicShipBuilder CreateBasicShipBuilder()
        {
            return new BasicShipBuilder();
        }

        [TestMethod]
        public void BuildShipColor_StateUnderTest_ExpectedBehavior()
        {

            Ship ship = new Basic();
            // Arrange
            var basicShipBuilder = this.CreateBasicShipBuilder();

            // Act
            basicShipBuilder.startNew(ship);
            basicShipBuilder.BuildShipColor();
            Assert.AreEqual(ship.Color, BattleShipV3.Data.Enums.ShipColor.WHITE);
        }
    }
}
