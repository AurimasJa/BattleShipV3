using BattleShipV3.Client.DesignPatterns.Strategy;
using BattleShipV3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestProject.DesignPatterns.Strategy
{
    [TestClass]
    public class FilterStrategyByMoreMaxEloTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private FilterStrategyByMoreMaxElo CreateFilterStrategyByMoreMaxElo()
        {
            return new FilterStrategyByMoreMaxElo();
        }

        [TestMethod]
        public void FilterFunction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var filterStrategyByMoreMax = this.CreateFilterStrategyByMoreMaxElo();
            Listing element = new Listing
            {
                Id = 1,
                EloFrom = 20,
                EloTo = 250,
                PlayerOne = new User
                {
                    Id = 1,
                    Name = "Benas"
                },
            };
            string searchString = "55";

            // Act
            var result = filterStrategyByMoreMax.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FilterFunction_StateUnderTest_NotExpectedBehavior()
        {
            // Arrange
            var filterStrategyByMoreMax = this.CreateFilterStrategyByMoreMaxElo();
            Listing element = new Listing
            {
                Id = 1,
                EloFrom = 20,
                EloTo = 250,
                PlayerOne = new User
                {
                    Id = 1,
                    Name = "Benas"
                },
            };
            string searchString = "5533";

            // Act
            var result = filterStrategyByMoreMax.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
