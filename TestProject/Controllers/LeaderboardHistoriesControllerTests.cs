using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class LeaderboardHistoriesControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ILeaderboardHistoriesRepository> mockLeaderboardHistoriesRepository;
        private Mock<IUsersRepository> mockUsersRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLeaderboardHistoriesRepository = this.mockRepository.Create<ILeaderboardHistoriesRepository>();
            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
        }

        private LeaderboardHistoriesController CreateLeaderboardHistoriesController()
        {
            return new LeaderboardHistoriesController(
                this.mockLeaderboardHistoriesRepository.Object,
                this.mockUsersRepository.Object);
        }

        [TestMethod]
        public async Task GetLeaderboardHistoryAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var leaderboardHistoriesController = this.CreateLeaderboardHistoriesController();
            int? id = null;

            // Act
            var result = await leaderboardHistoriesController.GetLeaderboardHistoryAsync(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetLeaderboardHistoriesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var leaderboardHistoriesController = this.CreateLeaderboardHistoriesController();

            // Act
            var result = await leaderboardHistoriesController.GetLeaderboardHistoriesAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateLeaderboardHistoryAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var leaderboardHistoriesController = this.CreateLeaderboardHistoriesController();
            CreateLeaderboardHistoryCommand createLeaderboardHistoryCommand = null;

            // Act
            var result = await leaderboardHistoriesController.CreateLeaderboardHistoryAsync(
                createLeaderboardHistoryCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateLeaderboardHistoryAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var leaderboardHistoriesController = this.CreateLeaderboardHistoriesController();
            int leaderboardHistoryId = 0;
            UpdateLeaderboardHistoryCommand updateLeaderboardHistoryCommand = null;

            // Act
            var result = await leaderboardHistoriesController.UpdateLeaderboardHistoryAsync(
                leaderboardHistoryId,
                updateLeaderboardHistoryCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task RemoveLeaderboardHistoryAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var leaderboardHistoriesController = this.CreateLeaderboardHistoriesController();
            int leaderboardHistoryId = 0;

            // Act
            var result = await leaderboardHistoriesController.RemoveLeaderboardHistoryAsync(
                leaderboardHistoryId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
