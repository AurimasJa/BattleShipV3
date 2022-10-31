
using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using BattleShipV3.Shared.Data.Commands.Listing.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;

public class GameMatchService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public GameMatchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<BattleShipV3.Models.GameMatch> GetGameMatchAsync(int gameMatchesId)
    {
        var gameMatch = await _httpClient.GetStringAsync($"{baseUrl}/gamematches/{gameMatchesId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Models.GameMatch>(gameMatch);
    }
    public async Task<List<BattleShipV3.Models.GameMatch>> GetGameMatchesAsync()
    {
        var gameMatch = await _httpClient.GetStringAsync($"{baseUrl}/gamematches"); // ??
        return JsonConvert.DeserializeObject<List<BattleShipV3.Models.GameMatch>>(gameMatch);
    }
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<GameMatch> InsertGameMatchAsync(CreateGameMatchCommand createGameMatchCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/gamematches", RequestHelper.GetStringContentFromObject(createGameMatchCommand));
        return JsonConvert.DeserializeObject<GameMatch>(await json.Content.ReadAsStringAsync());
    }
    public async Task<HttpResponseMessage> UpdateGameMatchAsync(int gameMatchesId, UpdateGameMatchCommand updateGameMatchCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/gamematches/{gameMatchesId}", RequestHelper.GetStringContentFromObject(updateGameMatchCommand));
    }
    public async Task<HttpResponseMessage> DeleteGameMatchAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{baseUrl}/gamematches/{id}");
    }
}

