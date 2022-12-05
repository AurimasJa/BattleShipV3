using BattleShipV3.Server.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Hubs
{
    [TestClass]
    public class GameHubTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private GameHub CreateGameHub()
        {
            return new GameHub();
        }

        [TestMethod]
        public async Task ShipPlacementFinished_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameHub = this.CreateGameHub();
            int listingId = 0;

            // Act
            await gameHub.ShipPlacementFinished(
                listingId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task JoinRoom_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameHub = this.CreateGameHub();
            int LobbyId = 0;

            // Act
            await gameHub.JoinRoom(
                LobbyId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task SendFireInfoAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameHub = this.CreateGameHub();
            int listingId = 0;
            int x = 0;
            int y = 0;
            int userId = 0;

            // Act
            await gameHub.SendFireInfoAsync(
                listingId,
                x,
                y,
                userId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task SendMissileLandResultAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameHub = this.CreateGameHub();
            int listingId = 0;
            bool isHit = false;
            int userId = 0;

            // Act
            await gameHub.SendMissileLandResultAsync(
                listingId,
                isHit,
                userId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task OnConnectedAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameHub = this.CreateGameHub();

            // Act
            await gameHub.OnConnectedAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task OnDisconnectedAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameHub = this.CreateGameHub();
            Exception? exception = null;

            // Act
            await gameHub.OnDisconnectedAsync(
                exception);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
