using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using BattleShipV3.Shared.Data.Commands.Listing.Update;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class ListingsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IListingsRepository> mockListingsRepository;
        private Mock<IUsersRepository> mockUsersRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockListingsRepository = this.mockRepository.Create<IListingsRepository>();
            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
        }

        private ListingsController CreateListingsController()
        {
            return new ListingsController(
                this.mockListingsRepository.Object,
                this.mockUsersRepository.Object);
        }

        [TestMethod]
        public async Task GetListingAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listingsController = this.CreateListingsController();
            int? id = null;

            // Act
            var result = await listingsController.GetListingAsync(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetListingsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listingsController = this.CreateListingsController();

            // Act
            var result = await listingsController.GetListingsAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateListingAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listingsController = this.CreateListingsController();
            CreateListingCommand createListingCommand = null;

            // Act
            var result = await listingsController.CreateListingAsync(
                createListingCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateListingAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listingsController = this.CreateListingsController();
            int listingId = 0;
            UpdateListingCommand updateListingCommand = null;

            // Act
            var result = await listingsController.UpdateListingAsync(
                listingId,
                updateListingCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listingsController = this.CreateListingsController();
            int listingId = 0;

            // Act
            var result = await listingsController.Remove(
                listingId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
