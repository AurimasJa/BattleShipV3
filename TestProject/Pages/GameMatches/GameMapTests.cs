using BattleShipV3.Client.Pages.GameMatches;
using BattleShipV3.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using static BattleShipV3.Data.Enums;

namespace TestProject.Pages.GameMatches
{
    [TestClass]
    public class GameMapTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private GameMap CreateGameMap()
        {
            return new GameMap();
        }

        [TestMethod]
        public void OnClickGridPaper_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            int x = 0;
            int y = 0;
            bool isShooting = false;

            // Act
            gameMap.OnClickGridPaper(
                x,
                y,
                isShooting);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void MissileLand_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            int x = 0;
            int y = 0;

            // Act
            gameMap.MissileLand(
                x,
                y);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void FireMissile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            int x = 0;
            int y = 0;

            // Act
            gameMap.FireMissile(
                x,
                y);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AfterHit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            bool isHit = false;

            // Act
            gameMap.AfterHit(
                isHit);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetPhase_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();

            // Act
            var result = gameMap.GetPhase();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RefreshUI_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();

            // Act
            gameMap.RefreshUI();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SelectShip_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            Ship context = null;

            // Act
            gameMap.SelectShip(
                context);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ChangeShipColor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            Ship selectedShip = null;
            ShipColor color = default(global::BattleShipV3.Data.Enums.ShipColor);

            // Act
            gameMap.ChangeShipColor(
                selectedShip,
                color);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetColorChanger_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            ShipColor color = default(global::BattleShipV3.Data.Enums.ShipColor);

            // Act
            var result = gameMap.GetColorChanger(
                color);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void IsRotated_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            Ship? context = null;

            // Act
            var result = gameMap.IsRotated(
                context);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PlaceShip_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            int x = 0;
            int y = 0;

            // Act
            gameMap.PlaceShip(
                x,
                y);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ColorEnumToHex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameMap = this.CreateGameMap();
            Ship context = null;

            // Act
            var result = gameMap.ColorEnumToHex(
                context);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
