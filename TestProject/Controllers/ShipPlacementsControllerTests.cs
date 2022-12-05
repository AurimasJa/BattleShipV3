using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class ShipPlacementsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IShipPlacementsRepository> mockShipPlacementsRepository;
        private Mock<IGameMatchesRepository> mockGameMatchesRepository;
        private Mock<IUsersRepository> mockUsersRepository;
        private Mock<IShipsRepository> mockShipsRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockShipPlacementsRepository = this.mockRepository.Create<IShipPlacementsRepository>();
            this.mockGameMatchesRepository = this.mockRepository.Create<IGameMatchesRepository>();
            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
            this.mockShipsRepository = this.mockRepository.Create<IShipsRepository>();
        }

        private ShipPlacementsController CreateShipPlacementsController()
        {
            return new ShipPlacementsController(
                this.mockShipPlacementsRepository.Object,
                this.mockGameMatchesRepository.Object,
                this.mockUsersRepository.Object,
                this.mockShipsRepository.Object);
        }

        [TestMethod]
        public async Task GetShipPlacementAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipPlacementsController = this.CreateShipPlacementsController();
            int? id = null;

            // Act
            var result = await shipPlacementsController.GetShipPlacementAsync(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetShipPlacementsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipPlacementsController = this.CreateShipPlacementsController();

            // Act
            var result = await shipPlacementsController.GetShipPlacementsAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateShipPlacementAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipPlacementsController = this.CreateShipPlacementsController();
            CreateShipPlacementCommand createShipPlacementCommand = null;

            // Act
            var result = await shipPlacementsController.CreateShipPlacementAsync(
                createShipPlacementCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateShipPlacementAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipPlacementsController = this.CreateShipPlacementsController();
            int shipPlacementId = 0;
            UpdateShipPlacementCommand updateShipPlacementCommand = null;

            // Act
            var result = await shipPlacementsController.UpdateShipPlacementAsync(
                shipPlacementId,
                updateShipPlacementCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipPlacementsController = this.CreateShipPlacementsController();
            int shipPlacementId = 0;

            // Act
            var result = await shipPlacementsController.Remove(
                shipPlacementId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
