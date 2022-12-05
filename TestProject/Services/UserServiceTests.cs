using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.User.Create;
using BattleShipV3.Shared.Data.Commands.User.Update;
using BattleShipV3.Shared.Data.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Services
{
    [TestClass]
    public class UserServiceTests
    {
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

            UpdateUserCommand updateUserCommand = new UpdateUserCommand("Darius", "123@mail.com", null, null,null);
            var response = await _userService.UpdateUserAsync(TestsHelper._InsertedUserId.Value, updateUserCommand);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            //    Uri uri = new Uri($"https://localhost:5001/users/{TestsHelper._InsertedUserId}");

            //    UpdateUserCommand updateUserCommand = new UpdateUserCommand("asd", null, null, null, null);
            //    var response = httpClient.PutAsync(uri, RequestHelper.GetStringContentFromObject(updateUserCommand));

            //    Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task zRemove_StateUnderTest_ExpectedBehavior()
        {
            var response = await _userService.DeleteUserAsync(TestsHelper._InsertedUserId.Value);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NoContent);
            //Uri uri = new Uri($"https://localhost:5001/users/{TestsHelper._InsertedUserId}");
            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, uri);
            //var response = httpClient.Send(message);

            //Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }
    }
}
