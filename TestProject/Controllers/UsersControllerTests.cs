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
using static MudBlazor.CategoryTypes;

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
        private HttpClient httpClient = new HttpClient();
        private UserService _userService;

        [TestInitialize]
        public void TestInitialize()
        {
            Uri uri = new Uri("https://localhost:5001");
            httpClient.BaseAddress = uri;
            _userService = new UserService(httpClient);
        }

        [TestMethod]
        public async Task GetUsersAsync_StateUnderTest_ExpectedBehavior()
        {
            Uri uri = new Uri("https://localhost:5001/users/");
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = httpClient.Send(message);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task CreateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            CreateUserCommand createUserCommand = new CreateUserCommand("Darius", "Darius@mail.com", "passwoorrd");
            var response = await _userService.InsertUserAsync(createUserCommand);

            TestsHelper._InsertedUserId = int.Parse(await response.Content.ReadAsStringAsync());
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        }
        public Mock paymentServiceMock = new Mock<IUsersRepository>();
        [TestMethod]
        public async Task Method_GetUserAsync_StateUnderTest_ExpectedBehavior()
        {
            var response = await _userService.GetUserAsync(TestsHelper._InsertedUserId.Value);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetUserByEmailAsync_StateUnderTest_ExpectedBehavior()
        {
            string page = "https://localhost:5001/users" + "/email?email=Darius@mail.com";
            Uri uri = new Uri(page);


            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = httpClient.Send(message);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }



        [TestMethod]
        public async Task UpdateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            Uri uri = new Uri($"https://localhost:5001/users/{TestsHelper._InsertedUserId}");

            UpdateUserCommand updateUserCommand = new UpdateUserCommand("asd", null, null, null, null);
            var response = httpClient.PutAsync(uri, RequestHelper.GetStringContentFromObject(updateUserCommand));

            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task zRemove_StateUnderTest_ExpectedBehavior()
        {
            Uri uri = new Uri($"https://localhost:5001/users/{TestsHelper._InsertedUserId}");
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, uri);
            var response = httpClient.Send(message);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }
    }
}
