
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Commands.User.Create;
using BattleShipV3.Shared.Data.Commands.User.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;

public class TurnService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public TurnService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<Turn> GetTurnAsync(int id)
    {
        var turn = await _httpClient.GetStringAsync($"{baseUrl}/turns/{id}");
        return JsonConvert.DeserializeObject<Turn>(turn);
    }
    public async Task<List<Turn>> GetTurnsAsync()
    {
        var turn = await _httpClient.GetStringAsync($"{baseUrl}/turns");
        return JsonConvert.DeserializeObject<List<Turn>>(turn);
    }

    public async Task<HttpResponseMessage> InsertTurnAsync(CreateTurnCommand createTurnCommand)
    {
        return await _httpClient.PostAsync($"{baseUrl}/turns", RequestHelper.GetStringContentFromObject(createTurnCommand));
    }

    public async Task<HttpResponseMessage> DeleteTurnAsync(int turnId)
    {
        return await _httpClient.DeleteAsync($"{baseUrl}/turns/{turnId}");
    }

}
