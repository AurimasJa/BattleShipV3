﻿using BattleShipV3.Client.DesignPatterns.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject.DesignPatterns.Factory
{
    [TestClass]
    public class TicketPurchaseFactoryTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private TicketPurchaseFactory CreateFactory()
        {
            return new TicketPurchaseFactory();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act


            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
