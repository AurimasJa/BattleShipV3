using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Ship.Create;
using BattleShipV3.Shared.Data.Commands.Ship.Update;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class ShipsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IShipsRepository> mockShipsRepository;
        private Mock<IMissilesRepository> mockMissilesRepository;
        private Mock<IUsersRepository> mockUsersRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockShipsRepository = this.mockRepository.Create<IShipsRepository>();
            this.mockMissilesRepository = this.mockRepository.Create<IMissilesRepository>();
            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
        }

        private ShipsController CreateShipsController()
        {
            return new ShipsController(
                this.mockShipsRepository.Object,
                this.mockMissilesRepository.Object,
                this.mockUsersRepository.Object);
        }

        [TestMethod]
        public async Task GetShipsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var controller = CreateShipsController();
            // Act
            var result = controller.GetShipsAsync();
            // Assert
            var okResult = result.Status;
            Assert.Fail();
            //okResult.Value.Should().Be("API is working!");

        }

        [TestMethod]
        public async Task GetAllUserShipsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipsController = this.CreateShipsController();
            int? userId = null;
            bool? selected = null;

            // Act
            var result = await shipsController.GetAllUserShipsAsync(
                userId,
                selected);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateShipAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipsController = this.CreateShipsController();
            CreateShipCommand createShipCommand = null;

            // Act
            var result = await shipsController.CreateShipAsync(
                createShipCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateUserShipsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipsController = this.CreateShipsController();
            CreateUserSelectedShipCommand createUserSelectedShipCommand = null;

            // Act
            var result = await shipsController.CreateUserShipsAsync(
                createUserSelectedShipCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateShipAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipsController = this.CreateShipsController();
            int shipId = 0;
            UpdateShipCommand updateShipCommand = null;

            // Act
            var result = await shipsController.UpdateShipAsync(
                shipId,
                updateShipCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task RemoveUserSelectedShip_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var shipsController = this.CreateShipsController();
            int userId = 0;
            int shipId = 0;

            // Act
            var result = await shipsController.RemoveUserSelectedShip(
                userId,
                shipId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
