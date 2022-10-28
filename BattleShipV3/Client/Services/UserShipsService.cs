using BattleShipV3.Shared.Data.Commands.User.Create;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;

namespace BattleShipV3.Client.Services
{
    public class UserShipsService
    {
        private readonly HttpClient _httpClient;

        string baseUrl;

        public UserShipsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            this.baseUrl = "https://localhost:5001";
        }

        public async Task<HttpResponseMessage> InsertUserShipsAsync(CreateUserShipsCommand createUserShipsCommand)
        {
            return await _httpClient.PostAsync($"{baseUrl}/pointsshop", RequestHelper.GetStringContentFromObject(createUserShipsCommand));
        }
    }
}
