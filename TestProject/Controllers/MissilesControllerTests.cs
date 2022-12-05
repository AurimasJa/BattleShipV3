using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Missile.Create;
using BattleShipV3.Shared.Data.Commands.Missile.Update;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class MissilesControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IMissilesRepository> mockMissilesRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMissilesRepository = this.mockRepository.Create<IMissilesRepository>();
        }

        private MissilesController CreateMissilesController()
        {
            return new MissilesController(
                this.mockMissilesRepository.Object);
        }

        [TestMethod]
        public async Task GetMissileAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var missilesController = this.CreateMissilesController();
            int? id = null;

            // Act
            var result = await missilesController.GetMissileAsync(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetMissilesAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var missilesController = this.CreateMissilesController();

            // Act
            var result = await missilesController.GetMissilesAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task CreateMissileAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var missilesController = this.CreateMissilesController();
            CreateShipCommand createMissileCommand = null;

            // Act
            var result = await missilesController.CreateMissileAsync(
                createMissileCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateListingAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var missilesController = this.CreateMissilesController();
            int missileId = 0;
            UpdateShipCommand updateMissileCommand = null;

            // Act
            var result = await missilesController.UpdateListingAsync(
                missileId,
                updateMissileCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var missilesController = this.CreateMissilesController();
            int missileId = 0;

            // Act
            var result = await missilesController.Remove(
                missileId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
