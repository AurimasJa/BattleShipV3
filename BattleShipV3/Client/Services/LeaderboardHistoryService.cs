
using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;

public class LeaderboardHistoryService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public LeaderboardHistoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<LeaderboardHistory> GetLeaderboardHistoryAsync(int leaderboradHistoryId)
    {
        var leaderboardHistory = await _httpClient.GetStringAsync($"{baseUrl}/leaderboardHistories/{leaderboradHistoryId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Models.LeaderboardHistory>(leaderboardHistory);
    }
    public async Task<List<LeaderboardHistory>> GetLeaderboardHistoriesAsync()
    {
        var leaderboardHistory = await _httpClient.GetStringAsync($"{baseUrl}/leaderboardHistories"); // ??
        return JsonConvert.DeserializeObject<List<LeaderboardHistory>>(leaderboardHistory);
    }
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<LeaderboardHistory> InsertLeaderboardHistoryAsync(CreateLeaderboardHistoryCommand createLeaderboardHistoryCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/leaderboardHistories", RequestHelper.GetStringContentFromObject(createLeaderboardHistoryCommand));
        return JsonConvert.DeserializeObject<LeaderboardHistory>(await json.Content.ReadAsStringAsync());
    }
    public async Task<HttpResponseMessage> UpdateLeaderboardHistoryAsync(int leaderboradHistoryId, UpdateLeaderboardHistoryCommand updateLeaderboardHistoryCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/leaderboardHistories/{leaderboradHistoryId}", RequestHelper.GetStringContentFromObject(updateLeaderboardHistoryCommand));
    }
}

