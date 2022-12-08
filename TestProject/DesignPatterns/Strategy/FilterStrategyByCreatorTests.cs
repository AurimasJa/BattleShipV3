using BattleShipV3.Client.DesignPatterns.Strategy;
using BattleShipV3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestProject.DesignPatterns.Strategy
{
    [TestClass]
    public class FilterStrategyByCreatorTests
    {

        private FilterStrategyByCreator CreateFilterStrategyByCreator()
        {
            return new FilterStrategyByCreator();
        }

        [TestMethod]
        public void FilterFunction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var filterStrategyByCreator = this.CreateFilterStrategyByCreator();
            Listing element = new Listing
            {
                Id = 1,
                EloFrom = 20,
                PlayerOne = new User
                {
                    Id = 1,
                    Name = "Benas"
                },
            };
            string searchString = "Ben";

            // Act
            var result = filterStrategyByCreator.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FilterFunction_StateUnderTest_NotExpectedBehavior()
        {
            // Arrange
            var filterStrategyByCreator = this.CreateFilterStrategyByCreator();
            Listing element = new Listing
            {
                Id = 1,
                EloFrom = 20,
                PlayerOne = new User
                {
                    Id = 1,
                    Name = "Benas"
                },
            };
            string searchString = "123";

            // Act
            var result = filterStrategyByCreator.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
