//using BattleShipV3.Client.Pages.PointsShop;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using static BattleShipV3.Data.Enums;

//namespace TestProject.Pages.PointsShop
//{
//    [TestClass]
//    public class PointsShopTests
//    {
//        private MockRepository mockRepository;



//        [TestInitialize]
//        public void TestInitialize()
//        {
//            this.mockRepository = new MockRepository(MockBehavior.Strict);


//        }

//        private PointsShop CreatePointsShop()
//        {
//            return new PointsShop();
//        }

//        [TestMethod]
//        public void SetPurchaseType_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var pointsShop = this.CreatePointsShop();
//            PurchaseType type = default(global::BattleShipV3.Data.Enums.PurchaseType);

//            // Act
//            pointsShop.SetPurchaseType(
//                type);

//            // Assert
//            Assert.Fail();
//            this.mockRepository.VerifyAll();
//        }
//    }
//}
