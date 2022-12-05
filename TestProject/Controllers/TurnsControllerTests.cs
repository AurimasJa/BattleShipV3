using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class TurnsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ITurnsRepository> mockTurnsRepository;
        private Mock<IGameMatchesRepository> mockGameMatchesRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTurnsRepository = this.mockRepository.Create<ITurnsRepository>();
            this.mockGameMatchesRepository = this.mockRepository.Create<IGameMatchesRepository>();
        }

        private TurnsController CreateTurnsController()
        {
            return new TurnsController(
                this.mockTurnsRepository.Object,
                this.mockGameMatchesRepository.Object);
        }

        [TestMethod]
        public async Task GetTurnAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var turnsController = this.CreateTurnsController();
            int? id = null;

            // Act
            var result = await turnsController.GetTurnAsync(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetTurnsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var turnsController = this.CreateTurnsController();

            // Act
            var result = await turnsController.GetTurnsAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateTurnAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var turnsController = this.CreateTurnsController();
            CreateTurnCommand createTurnCommand = null;

            // Act
            var result = await turnsController.CreateTurnAsync(
                createTurnCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var turnsController = this.CreateTurnsController();
            int turnId = 0;

            // Act
            var result = await turnsController.Remove(
                turnId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
