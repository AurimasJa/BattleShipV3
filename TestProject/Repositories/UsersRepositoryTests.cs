using BattleShipV3;
using BattleShipV3.Server.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Repositories
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<BattleshipDbContext> mockBattleshipDbContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockBattleshipDbContext = this.mockRepository.Create<BattleshipDbContext>();
        }

        private UsersRepository CreateUsersRepository()
        {
            return new UsersRepository(
                this.mockBattleshipDbContext.Object);
        }

        [TestMethod]
        public async Task GetAllUsersAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersRepository = this.CreateUsersRepository();

            // Act
            var result = await usersRepository.GetAllUsersAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetUserAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersRepository = this.CreateUsersRepository();
            int? userId = null;
            string? email = null;

            // Act
            var result = await usersRepository.GetUserAsync(
                userId,
                email);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersRepository = this.CreateUsersRepository();
            User user = null;

            // Act
            await usersRepository.CreateUserAsync(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersRepository = this.CreateUsersRepository();
            User user = null;

            // Act
            await usersRepository.UpdateUserAsync(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task DeleteUserAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersRepository = this.CreateUsersRepository();
            User user = null;

            // Act
            await usersRepository.DeleteUserAsync(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
