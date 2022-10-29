using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.Ship.Create;
using BattleShipV3.Shared.Data.Commands.Ship.Get;
using BattleShipV3.Shared.Data.Commands.Ship.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class ShipService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public ShipService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<BattleShipV3.Data.Models.Ship> GetShipAsync(int shipId)
    {
        var ship = await _httpClient.GetStringAsync($"{baseUrl}/ships/{shipId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Data.Models.Ship>(ship);
    }
    public async Task<List<BattleShipV3.Data.Models.Ship>> GetShipAsync()
    {
        var ship = await _httpClient.GetStringAsync($"{baseUrl}/ships"); // ??
        return JsonConvert.DeserializeObject<List<BattleShipV3.Data.Models.Ship>>(ship);
    }
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<Ship> InsertShipAsync(CreateShipCommand createShipCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/ships", RequestHelper.GetStringContentFromObject(createShipCommand));
        return JsonConvert.DeserializeObject<Ship>(await json.Content.ReadAsStringAsync());
    }
    public async Task<HttpResponseMessage> UpdateShipAsync(int shipId, UpdateShipCommand updateShipCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/ships/{shipId}", RequestHelper.GetStringContentFromObject(updateShipCommand));
    }
}

