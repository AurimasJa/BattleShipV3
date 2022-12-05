using BattleShipV3.Client.DesignPatterns.Command;
using BattleShipV3.Client.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.DesignPatterns.Command
{
    [TestClass]
    public class SelectShipCommandTests
    {
        private MockRepository mockRepository;

        private Mock<ShipService> mockShipService;
        private Mock<UserShipsService> mockUserShipsService;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockShipService = this.mockRepository.Create<ShipService>();
            this.mockUserShipsService = this.mockRepository.Create<UserShipsService>();
        }

        private SelectShipCommand CreateSelectShipCommand()
        {
            return new SelectShipCommand(
                this.mockShipService.Object,
                this.mockUserShipsService.Object);
        }

        [TestMethod]
        public async Task Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var selectShipCommand = this.CreateSelectShipCommand();
            int userId = 0;
            int shipId = 0;

            // Act
            await selectShipCommand.Execute(
                userId,
                shipId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var selectShipCommand = this.CreateSelectShipCommand();
            int userId = 0;
            int shipId = 0;

            // Act
            await selectShipCommand.Undo(
                userId,
                shipId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
