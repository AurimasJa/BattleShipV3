using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class GameMatchesControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IListingsRepository> mockListingsRepository;
        private Mock<IUsersRepository> mockUsersRepository;
        private Mock<IGameMatchesRepository> mockGameMatchesRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockListingsRepository = this.mockRepository.Create<IListingsRepository>();
            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
            this.mockGameMatchesRepository = this.mockRepository.Create<IGameMatchesRepository>();
        }

        private GameMatchesController CreateGameMatchesController()
        {
            return new GameMatchesController(
                this.mockListingsRepository.Object,
                this.mockUsersRepository.Object,
                this.mockGameMatchesRepository.Object);
        }

        [TestMethod]
        public async Task GetGameMatchAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMatchesController = this.CreateGameMatchesController();
            int? id = null;

            // Act
            var result = await gameMatchesController.GetGameMatchAsync(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetGameMatchesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMatchesController = this.CreateGameMatchesController();

            // Act
            var result = await gameMatchesController.GetGameMatchesAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateGameMatchAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMatchesController = this.CreateGameMatchesController();
            CreateGameMatchCommand createGameMatchCommand = null;

            // Act
            var result = await gameMatchesController.CreateGameMatchAsync(
                createGameMatchCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateListingAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMatchesController = this.CreateGameMatchesController();
            int gameMatchId = 0;
            UpdateGameMatchCommand updateGameMatchCommand = null;

            // Act
            var result = await gameMatchesController.UpdateListingAsync(
                gameMatchId,
                updateGameMatchCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMatchesController = this.CreateGameMatchesController();
            int gameMatchId = 0;

            // Act
            var result = await gameMatchesController.Remove(
                gameMatchId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
