using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.User.Create;
using BattleShipV3.Shared.Data.Commands.User.Update;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class UserService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }
    public async Task<BattleShipV3.Models.User> GetUserAsync(int id)
    {
        var user = await _httpClient.GetStringAsync($"{baseUrl}/users/{id}");
        return JsonConvert.DeserializeObject<BattleShipV3.Models.User>(user);
    }

    public async Task<BattleShipV3.Models.User> GetUserAsync(string email)
    {
        var user = await _httpClient.GetStringAsync($"{baseUrl}/users/email?email={email}");
        return JsonConvert.DeserializeObject<BattleShipV3.Models.User>(user);
    }

    public async Task<List<BattleShipV3.Models.User>> GetUsersAsync()
    {
        var user = await _httpClient.GetStringAsync($"{baseUrl}/users");
        return JsonConvert.DeserializeObject<List<BattleShipV3.Models.User>>(user);
    }
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<HttpResponseMessage> InsertUserAsync(CreateUserCommand createUserCommand)
    {
        return await _httpClient.PostAsync($"{baseUrl}/users", RequestHelper.GetStringContentFromObject(createUserCommand));
    }
    public async Task<HttpResponseMessage> UpdateUserAsync(int id,UpdateUserCommand updateUserCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/users/{id}", RequestHelper.GetStringContentFromObject(updateUserCommand));
    }
    public async Task<HttpResponseMessage> DeleteUserAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{baseUrl}/users/{id}");
    }
}

