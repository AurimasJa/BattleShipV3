using BattleShipV3.Models;
using BattleShipV3.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace TestProject.Hubs
{
    [TestClass]
    public class ChatHubTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ChatHub CreateChatHub()
        {
            return new ChatHub();
        }

        [TestMethod]
        public async Task SendMessage_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var chatHub = this.CreateChatHub();
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);


            ChatHub simpleHub = new ChatHub()
            {
                Clients = mockClients.Object
            };
            // act
            await simpleHub.SendMessage("asd", "asd");


            // assert
            mockClients.Verify(clients => clients.All, Times.Once);

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "asd",
                    It.Is<object[]>(o => o != null && o.Length == 1/* && ((object[])o[0]).Length == 3*/),
                    default(CancellationToken)),
                Times.Once);
        }
    }
}
