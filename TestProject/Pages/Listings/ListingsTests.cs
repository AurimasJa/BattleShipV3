using BattleShipV3.Client.DesignPatterns.Decorator;
using BattleShipV3.Client.Pages.Listings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Pages.Listings
{
    [TestClass]
    public class ListingsTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Listings CreateListings()
        {
            return new Listings();
        }

        [TestMethod]
        public async Task CreateLobby_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listings = this.CreateListings();
            CreateListingComponent listingComp = null;

            // Act
            await listings.CreateLobby(
                listingComp);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SetStrategy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listings = this.CreateListings();
            string strategy = null;

            // Act
            listings.SetStrategy(
                strategy);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task DisposeAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listings = this.CreateListings();

            // Act
            var result = await listings.DisposeAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
