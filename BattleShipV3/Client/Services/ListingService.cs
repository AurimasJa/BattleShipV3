using BattleShipV3.Models;
using BattleShipV3.Shared.Data;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using BattleShipV3.Shared.Data.Commands.Listing.Update;
using BattleShipV3.Shared.Data.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class ListingService
{
    private readonly HttpClient _httpClient;

    string baseUrl;

    public ListingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        this.baseUrl = "https://localhost:5001";
    }

    public async Task<BattleShipV3.Models.Listing> GetListingAsync(int listingId)
    {
        var listing = await _httpClient.GetStringAsync($"{baseUrl}/listings/{listingId}"); // ?? email?email={email}"
        return JsonConvert.DeserializeObject<BattleShipV3.Models.Listing>(listing);
    }
    public async Task<List<BattleShipV3.Models.Listing>> GetListingsAsync()
    {
        var listing = await _httpClient.GetStringAsync($"{baseUrl}/listings"); // ??
        return JsonConvert.DeserializeObject<List<BattleShipV3.Models.Listing>>(listing);
    }
    //public async Task<List<>>
    //public async Task<List<>>
    public async Task<Listing> InsertListingAsync(CreateListingCommand createListingCommand)
    {
        var json = await _httpClient.PostAsync($"{baseUrl}/listings", RequestHelper.GetStringContentFromObject(createListingCommand));
        return JsonConvert.DeserializeObject<Listing>(await json.Content.ReadAsStringAsync());
    }
    public async Task<HttpResponseMessage> UpdateListingAsync(int listingId, UpdateListingCommand updateListingCommand)
    {
        return await _httpClient.PutAsync($"{baseUrl}/listings/{listingId}", RequestHelper.GetStringContentFromObject(updateListingCommand));
    }
}

