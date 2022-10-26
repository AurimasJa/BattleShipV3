using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.User.Create;
using BattleShipV3.Shared.Data.Commands.User.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BattleShipV3.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        string baseUrl;

        public UserService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            this.baseUrl = baseUrl;
        }

        public async Task<Models.User> GetUserAsync()
        {
            var user = await _httpClient.GetStringAsync($"{baseUrl}/users");
            return JsonConvert.DeserializeObject<Models.User>(user);
        }
        public async Task<List<Models.User>> GetUsersAsync()
        {
            var user = await _httpClient.GetStringAsync($"{baseUrl}/users");
            return JsonConvert.DeserializeObject<List<Models.User>>(user);
        }
        //public async Task<List<>>
        //public async Task<List<>>
        public async Task<HttpResponseMessage> InsertUserAsync(CreateUserCommand createUserCommand)
        {
            return await _httpClient.PostAsync($"{baseUrl}/users", RequestHelper.GetStringContentFromObject(createUserCommand));
        }
        public async Task<HttpResponseMessage> UpdateUserAsync(UpdateUserCommand createUserCommand)
        {
            return await _httpClient.PostAsync($"{baseUrl}/users", RequestHelper.GetStringContentFromObject(createUserCommand));
        }
    }
}
