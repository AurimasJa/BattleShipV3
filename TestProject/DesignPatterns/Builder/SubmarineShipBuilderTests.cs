using BattleShipV3.Client.DesignPatterns.Builder;
using BattleShipV3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.DesignPatterns.Builder
{
    [TestClass]
    public class SubmarineShipBuilderTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private SubmarineShipBuilder CreateSubmarineShipBuilder()
        {
            return new SubmarineShipBuilder();
        }

        [TestMethod]
        public void BuildShipColor_StateUnderTest_ExpectedBehavior()
        {
            Ship ship = new Submarine();
            // Arrange
            var submarineShipBuilder = this.CreateSubmarineShipBuilder();

            // Act
            submarineShipBuilder.startNew(ship);
            submarineShipBuilder.BuildShipColor();
            Assert.AreEqual(ship.Color, BattleShipV3.Data.Enums.ShipColor.BLUE);
        }
    }
}
