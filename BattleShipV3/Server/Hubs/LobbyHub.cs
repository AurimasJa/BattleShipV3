using Microsoft.AspNetCore.SignalR;

namespace BattleShipV3.Server.Hubs
{

    public class LobbyHubb : Hub
    {
        public async Task CreateLobby(Models.User user, Models.Listing lobby)
        {
            await Clients.All.SendAsync("CreateListing", user, lobby);
        }
    }
}