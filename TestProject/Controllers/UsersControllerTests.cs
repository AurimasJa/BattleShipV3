using BattleShipV3.Models;
using BattleShipV3.Server.Controllers;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.User.Create;
using BattleShipV3.Shared.Data.Commands.User.Update;
using BattleShipV3.Shared.Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    [TestClass]
    public class UsersControllerTests
    {

        private readonly Mock<HttpContext> _context;
        private readonly Mock<HttpRequest> _request;
        private readonly Mock<IUsersRepository> _usersRepository;


        private MockRepository mockRepository;

        private Mock<IUsersRepository> mockUsersRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUsersRepository = this.mockRepository.Create<IUsersRepository>();
        }

        private UsersController CreateUsersController()
        {
            //UsersRepository usersRepository = new UsersRepository()
            return new UsersController(
                this.mockUsersRepository.Object);
        }
        public HttpClient httpClient = new HttpClient();

        [TestMethod]
        public async Task GetUsersAsync_StateUnderTest_ExpectedBehavior()
        {
            Uri uri = new Uri("https://localhost:5001/users");
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = httpClient.Send(message);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
        [TestMethod]
        public async Task CreateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            Uri uri = new Uri("https://localhost:5001/users");

            CreateUserCommand createUserCommand = new CreateUserCommand("Darius", "Darius@mail.com", "passwoorrd");
            var response = httpClient.PostAsync(uri, RequestHelper.GetStringContentFromObject(createUserCommand));
            Console.WriteLine(response.Status);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
        }
        public Mock paymentServiceMock = new Mock<IUsersRepository>();
        [TestMethod]
        public async Task Method_GetUserAsync_StateUnderTest_ExpectedBehavior()
        {

            var usersController = this.CreateUsersController();
            var okResult = usersController.GetUserAsync(1);
            Assert.AreEqual(okResult.Result.Value.Name, "laucek");
           
        }

        [TestMethod]
        public async Task GetUserByEmailAsync_StateUnderTest_ExpectedBehavior()
        {
            string page = "https://localhost:5001/users" + "/email?email=Darius@mail.com";
            Uri uri = new Uri(page);


            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = httpClient.Send(message);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }



        [TestMethod]
        public async Task UpdateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            //string page = "https://localhost:5001/users" + "/email?email=Darius@mail.com";
            //Uri uri = new Uri(page);
            //UpdateUserCommand updateUserCommand = new UpdateUserCommand("Darius", "Darius@mail.com", null, null,null);
            //_httpClient.PutAsync($"{baseUrl}/users/{id}", RequestHelper.GetStringContentFromObject(updateUserCommand));

            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);
            //var response = httpClient.Send(message);
            //var jsonString = await response.Content.ReadAsStringAsync();
            //var user = JsonConvert.DeserializeObject<object>(jsonString);
            
            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, uri);
            //Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            int userId = 0;

            // Act
            var result = await usersController.Remove(
                userId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
