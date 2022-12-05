using BattleShipV3.Client.Pages.GameMatches;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BattleShipV3.Client.Pages.GameMatches.GameMap;

namespace TestProject.Pages.GameMatches
{
    [TestClass]
    public class GameMatchComponentTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private GameMatchComponent CreateComponent()
        {
            return new GameMatchComponent();
        }

        [TestMethod]
        public async Task FireMissile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();
            FireMissileEventArgs args = null;

            // Act
            await component.FireMissile(
                args);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AssignDefaultRotations_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();
            List<Ship> ships = null;

            // Act
            component.AssignDefaultRotations(
                ships);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task AfterLandMissile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();
            MissileLandEventArgs args = null;

            // Act
            await component.AfterLandMissile(
                args);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ShipPhaseFinished_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();

            // Act
            component.ShipPhaseFinished();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UserFinishedShipPhase_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();

            // Act
            await component.UserFinishedShipPhase();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void BuildShips_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var component = this.CreateComponent();
            GamePlayerModel player = null;
            List<Ship> ships = null;

            // Act
            component.BuildShips(
                player,
                ships);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
