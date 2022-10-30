//using BattleShipV3.Models;
//using BattleShipV3.Data.Models;
//using BattleShipV3.Shared.Data;
//using BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;
//using BattleShipV3.Shared.Data.Commands.ShipPlacement.Get;
//using BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;
//using BattleShipV3.Shared.Data.Helpers;
//using Newtonsoft.Json;
//using System.Text.Json.Serialization;

//public class ShipPlacementService
//{
//    private readonly HttpClient _httpClient;

//    string baseUrl;

//    public ShipPlacementService(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//        this.baseUrl = "https://localhost:5001";
//    }

//    public async Task<BattleShipV3.Data.Models.ShipPlacement> GetShipPlacementAsync(int missileId)
//    {
//        var missile = await _httpClient.GetStringAsync($"{baseUrl}/listings/{missileId}"); // ?? email?email={email}"
//        return JsonConvert.DeserializeObject<BattleShipV3.Data.Models.ShipPlacement>(missile);
//    }
//    public async Task<List<BattleShipV3.Data.Models.ShipPlacement>> GetShipPlacementsAsync()
//    {
//        var missile = await _httpClient.GetStringAsync($"{baseUrl}/listings"); // ??
//        return JsonConvert.DeserializeObject<List<BattleShipV3.Data.Models.ShipPlacement>>(missile);
//    }
//    //public async Task<List<>>
//    //public async Task<List<>>
//    public async Task<ShipPlacement> InsertShipPlacementAsync(CreateShipPlacementCommand createShipPlacementCommand)
//    {
//        var json = await _httpClient.PostAsync($"{baseUrl}/listings", RequestHelper.GetStringContentFromObject(createShipPlacementCommand));
//        return JsonConvert.DeserializeObject<ShipPlacement>(await json.Content.ReadAsStringAsync());
//    }
//    public async Task<HttpResponseMessage> UpdateShipPlacementAsync(int missileId, UpdateShipPlacementCommand updateShipPlacementCommand)
//    {
//        return await _httpClient.PutAsync($"{baseUrl}/listings/{missileId}", RequestHelper.GetStringContentFromObject(updateShipPlacementCommand));
//    }
//}

