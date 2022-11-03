using BattleShipV3.Models;
using Microsoft.AspNetCore.SignalR;

namespace BattleShipV3.Server.Hubs
{

    public class GameHub : Hub
    {
        //Dictionary<PlayerPair> _players = new List<PlayerPair>();
        public async Task ShipPlacementFinished(int listingId)
        {
            await Clients.Group(listingId.ToString()).SendAsync("ShipPlacementFinished");
        }

        public async Task JoinRoom(int LobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, LobbyId.ToString());
        }

        public async Task SendFireInfoAsync(int listingId, int x, int y, int userId)
        {
            await Clients.Group(listingId.ToString()).SendAsync("SendFireInfoAsync", x, y, userId);
        }

        public async Task SendMissileLandResultAsync(int listingId, bool isHit, int userId)
        {
            await Clients.Group(listingId.ToString()).SendAsync("SendMissileLandResultAsync", isHit, userId);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        //public async Task CreatePlayerPair(User p1, User p2, )
        //{

        //}

    }

    public class PlayerPair
    {
        public int LobbyId { get; set; }
        public string PlayerOneConnectionId { get; set; }
        public string PlayerTwoConnectionId { get; set; }
    }
}