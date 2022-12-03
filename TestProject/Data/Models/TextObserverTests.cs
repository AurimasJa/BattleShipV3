using BattleShipV3.Client.DesignPatterns.Observer;
using BattleShipV3.Shared.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestProject.Data.Models
{
    [TestClass]
    public class TextObserverTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private TextObserver CreateTextObserver()
        {
            return new TextObserver();
        }

        [TestMethod]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var textObserver = this.CreateTextObserver();
            ButtonSubject subject = new ButtonSubject();
            subject.Attach(textObserver);
            subject.Count += 2;

            subject.Notify();
            // Act
            Assert.AreEqual(textObserver.Text, "2");

            // Assert
            //Assert.Fail();
            //this.mockRepository.VerifyAll();
        }
    }
}
