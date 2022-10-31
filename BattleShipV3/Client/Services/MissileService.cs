using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.Missile.Create;
using BattleShipV3.Shared.Data.Commands.Missile.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class MissileService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public MissileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<BattleShipV3.Data.Models.Missile> GetMissileAsync(int missileId)
    {
        var missile = await _httpClient.GetStringAsync($"{baseUrl}/missiles/{missileId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Data.Models.Missile>(missile);
    }
    public async Task<List<BattleShipV3.Data.Models.Missile>> GetMissileAsync()
    {
        var missile = await _httpClient.GetStringAsync($"{baseUrl}/missiles"); // ??
        return JsonConvert.DeserializeObject<List<BattleShipV3.Data.Models.Missile>>(missile);
    }
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<Missile> InsertMissileAsync(CreateShipCommand createMissileCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/missiles", RequestHelper.GetStringContentFromObject(createMissileCommand));
        return JsonConvert.DeserializeObject<Missile>(await json.Content.ReadAsStringAsync());
    }
    public async Task<HttpResponseMessage> UpdateMissileAsync(int missileId, UpdateShipCommand updateMissileCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/missiles/{missileId}", RequestHelper.GetStringContentFromObject(updateMissileCommand));
    }
    public async Task<HttpResponseMessage> DeleteMissileAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{baseUrl}/missiles/{id}");
    }
}

