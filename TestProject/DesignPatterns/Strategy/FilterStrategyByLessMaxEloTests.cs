using BattleShipV3.Client.DesignPatterns.Strategy;
using BattleShipV3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestProject.DesignPatterns.Strategy
{
    [TestClass]
    public class FilterStrategyByLessMaxEloTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private FilterStrategyByLessMaxElo CreateFilterStrategyByLessMaxElo()
        {
            return new FilterStrategyByLessMaxElo();
        }

        [TestMethod]
        public void FilterFunction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var filterStrategyByLessMaxElo = this.CreateFilterStrategyByLessMaxElo();
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
            string searchString = "2550";

            // Act
            var result = filterStrategyByLessMaxElo.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FilterFunction_StateUnderTest_NotExpectedBehavior()
        {
            // Arrange
            var filterStrategyByLessMaxElo = this.CreateFilterStrategyByLessMaxElo();
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
            string searchString = "20";

            // Act
            var result = filterStrategyByLessMaxElo.FilterFunction(
                element,
                searchString);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
