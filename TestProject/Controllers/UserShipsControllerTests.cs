using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class UserShipsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IUserShipsRepository> mockUserShipsRepository;
        private Mock<IUsersRepository> mockUsersRepository;
        private Mock<IShipsRepository> mockShipsRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUserShipsRepository = this.mockRepository.Create<IUserShipsRepository>();
            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
            this.mockShipsRepository = this.mockRepository.Create<IShipsRepository>();
        }

        private UserShipsController CreateUserShipsController()
        {
            return new UserShipsController(
                this.mockUserShipsRepository.Object,
                this.mockUsersRepository.Object,
                this.mockShipsRepository.Object);
        }

        [TestMethod]
        public async Task GetUserShipsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userShipsController = this.CreateUserShipsController();

            // Act
            var result = await userShipsController.GetUserShipsAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateUserShipsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userShipsController = this.CreateUserShipsController();
            CreateUserShipsCommand createUserShipsCommand = null;

            // Act
            var result = await userShipsController.CreateUserShipsAsync(
                createUserShipsCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
