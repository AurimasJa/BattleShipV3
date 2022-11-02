using BattleShipV3.Data.Models;
using BattleShipV3.Models;
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

        public async Task<List<UserShip>> GetUserShipsAsync()
        {
            var userShip = await _httpClient.GetStringAsync($"{baseUrl}/pointsshop");
            return JsonConvert.DeserializeObject<List<UserShip>>(userShip);
        }

        public async Task<UserShip> InsertUserShipsAsync(CreateUserShipsCommand createUserShipsCommand)
        {
            var json = await _httpClient.PostAsync($"{baseUrl}/pointsshop", RequestHelper.GetStringContentFromObject(createUserShipsCommand));
            return JsonConvert.DeserializeObject<UserShip>(await json.Content.ReadAsStringAsync());
        }

        public async Task RemoveUserSelectedShip(int userId, int shipId)
        {
            var json = await _httpClient.DeleteAsync($"{baseUrl}/ships?userId={userId}&shipId={shipId}");
        }
    }
}
