using BattleShipV3.Models;
using Microsoft.AspNetCore.SignalR;

namespace BattleShipV3.Server.Hubs
{

    public class LobbyHub : Hub
    {
        public async Task CreateListing(Listing lobby, Models.User user)
        {
            await Clients.All.SendAsync("CreateListing", lobby, user);
        }

        public async Task JoinedListing(Listing lobby, User user)
        {
            await Clients.All.SendAsync("JoinedListing", lobby, user);
        }

        public async Task LeftListing(Listing lobby, User user)
        {
            await Clients.All.SendAsync("LeftListing", lobby, user);
        }
    }
}