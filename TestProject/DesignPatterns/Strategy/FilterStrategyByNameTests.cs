using BattleShipV3.Client.DesignPatterns.Strategy;
using BattleShipV3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestProject.DesignPatterns.Strategy
{
    [TestClass]
    public class FilterStrategyByNameTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private FilterStrategyByName CreateFilterStrategyByName()
        {
            return new FilterStrategyByName();
        }

        [TestMethod]
        public void FilterFunction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var filterStrategyByName = this.CreateFilterStrategyByName();
            Listing element = new Listing
            {
                Id = 1,
                Name = "Lietus",
                EloFrom = 20,
                PlayerOne = new User
                {
                    Id = 1,
                    Name = "Benas"
                },
            };
            string searchString = "Lie";

            // Act
            var result = filterStrategyByName.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FilterFunction_StateUnderTest_NotExpectedBehavior()
        {
            // Arrange
            var filterStrategyByName = this.CreateFilterStrategyByName();
            Listing element = new Listing
            {
                Id = 1,
                Name = "Lietus",
                EloFrom = 20,
                PlayerOne = new User
                {
                    Id = 1,
                    Name = "Benas"
                },
            };
            string searchString = "55";

            // Act
            var result = filterStrategyByName.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
