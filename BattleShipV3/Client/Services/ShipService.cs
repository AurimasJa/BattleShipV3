using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.Ship.Create;
using BattleShipV3.Shared.Data.Commands.Ship.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;

public class ShipService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public ShipService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<Ship> GetShipAsync(int shipId)
    {
        var ship = await _httpClient.GetStringAsync($"{baseUrl}/ships/{shipId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Data.Models.Ship>(ship);
    }
    public async Task<List<Ship>> GetShipsAsync()
    {
        var ship = await _httpClient.GetStringAsync($"{baseUrl}/ships"); // ??
        return JsonConvert.DeserializeObject<List<BattleShipV3.Data.Models.Ship>>(ship);
    }
    public async Task<List<Ship>> GetShipsByUserAsync(int? userId, bool? selected = false)
    {
        var ship = await _httpClient.GetStringAsync($"{baseUrl}/ships/{userId}?selected={selected}"); // ??
        return JsonConvert.DeserializeObject<List<Ship>>(ship);
    }
    
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<Ship> InsertShipAsync(CreateShipCommand createShipCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/ships", RequestHelper.GetStringContentFromObject(createShipCommand));
        return JsonConvert.DeserializeObject<Ship>(await json.Content.ReadAsStringAsync());
    }

    public async Task<Ship> InsertUserSelectedShipAsync(CreateUserSelectedShipCommand createShipCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/ships/userselected", RequestHelper.GetStringContentFromObject(createShipCommand));
        return JsonConvert.DeserializeObject<Ship>(await json.Content.ReadAsStringAsync());
    }

    public async Task<HttpResponseMessage> UpdateShipAsync(int shipId, UpdateShipCommand updateShipCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/ships/{shipId}", RequestHelper.GetStringContentFromObject(updateShipCommand));
    }
    public async Task<HttpResponseMessage> DeleteShipAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{baseUrl}/ships/{id}");
    }
}

