using BattleShipV3.Client.DesignPatterns.Decorator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.DesignPatterns.Decorator
{
    [TestClass]
    public class CreateListingComponentTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private CreateListingComponent CreateComponent()
        {
            return new CreateListingComponent();
        }

        [TestMethod]
        public void GetCreatedListing_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();

            // Act
            var result = component.GetCreatedListing();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
