using BattleShipV3.Models;
using BattleShipV3.Server.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Hubs
{
    [TestClass]
    public class LobbyHubTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private LobbyHub CreateLobbyHub()
        {
            return new LobbyHub();
        }

        [TestMethod]
        public async Task CreateListing_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            Listing lobby = null;
            User user = null;

            // Act
            await lobbyHub.CreateListing(
                lobby,
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task AlertObservers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            Listing listing = null;
            List<string> connectionStrings = null;

            // Act
            await lobbyHub.AlertObservers(
                listing,
                connectionStrings);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task JoinLobby_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            int lobbyId = 0;

            // Act
            await lobbyHub.JoinLobby(
                lobbyId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task MoveToGameMatch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            int lobbyId = 0;

            // Act
            await lobbyHub.MoveToGameMatch(
                lobbyId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task JoinedListing_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            Listing lobby = null;
            User user = null;

            // Act
            await lobbyHub.JoinedListing(
                lobby,
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task LeftListing_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            Listing lobby = null;
            User user = null;

            // Act
            await lobbyHub.LeftListing(
                lobby,
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task DeleteListing_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            Listing lobby = null;
            User user = null;

            // Act
            await lobbyHub.DeleteListing(
                lobby,
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GameStart_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            Listing lobby = null;

            // Act
            await lobbyHub.GameStart(
                lobby);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task FetchUserCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();

            // Act
            await lobbyHub.FetchUserCount();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task AttachObserver_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            string connectionString = null;

            // Act
            await lobbyHub.AttachObserver(
                connectionString);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UserLoggedIn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            User user = null;

            // Act
            await lobbyHub.UserLoggedIn(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UserLoggedOff_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobbyHub = this.CreateLobbyHub();
            User user = null;

            // Act
            await lobbyHub.UserLoggedOff(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
