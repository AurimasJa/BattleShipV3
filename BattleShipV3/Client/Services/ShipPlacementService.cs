using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class ShipPlacementService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public ShipPlacementService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<BattleShipV3.Data.Models.ShipPlacement> GetShipPlacementAsync(int shipPlacementId)
    {
        var missile = await _httpClient.GetStringAsync($"{baseUrl}/shipPlacements/{shipPlacementId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Data.Models.ShipPlacement>(missile);
    }
    public async Task<List<BattleShipV3.Data.Models.ShipPlacement>> GetShipPlacementsAsync()
    {
        var shipPlacement = await _httpClient.GetStringAsync($"{baseUrl}/shipPlacements"); // ??
        return JsonConvert.DeserializeObject<List<BattleShipV3.Data.Models.ShipPlacement>>(shipPlacement);
    }


    public async Task<ShipPlacement> InsertShipPlacementAsync(CreateShipPlacementCommand createShipPlacementCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/shipPlacements", RequestHelper.GetStringContentFromObject(createShipPlacementCommand));
        return JsonConvert.DeserializeObject<ShipPlacement>(await json.Content.ReadAsStringAsync());
    }
    public async Task<HttpResponseMessage> UpdateShipPlacementAsync(int shipPlacementId, UpdateShipPlacementCommand updateShipPlacementCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/shipPlacements/{shipPlacementId}", RequestHelper.GetStringContentFromObject(updateShipPlacementCommand));
    }
    public async Task<HttpResponseMessage> DeleteShipPlacementAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{baseUrl}/shipPlacements/{id}");
    }
}

