using BattleShipV3.Client.DesignPatterns.Builder;
using BattleShipV3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.DesignPatterns.Builder
{
    [TestClass]
    public class HealerShipBuilderTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private HealerShipBuilder CreateHealerShipBuilder()
        {
            return new HealerShipBuilder();
        }

        [TestMethod]
        public void BuildShipColor_StateUnderTest_ExpectedBehavior()
        {
            Ship ship = new Healer();
            // Arrange
            var healerShipBuilder = this.CreateHealerShipBuilder();

            // Act
            healerShipBuilder.startNew(ship);
            healerShipBuilder.BuildShipColor();
            Assert.AreEqual(ship.Color, BattleShipV3.Data.Enums.ShipColor.GREEN);
        }
    }
}
