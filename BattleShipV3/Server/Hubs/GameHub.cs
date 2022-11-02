using BattleShipV3.Models;
using Microsoft.AspNetCore.SignalR;

namespace BattleShipV3.Server.Hubs
{

    public class GameHub : Hub
    {
        public async Task whasneaba(Listing lobby, Models.User user)
        {
            await Clients.All.SendAsync("CreateListing", lobby, user);
        }

       
    }
}