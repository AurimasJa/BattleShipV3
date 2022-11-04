using BattleShipV3.Client.DesignPatterns.Singleton;
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

        public async Task JoinLobby(int lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId.ToString());
        }

        public async Task MoveToGameMatch(int lobbyId)
        {
            await Clients.Group(lobbyId.ToString()).SendAsync("MoveToGameMatch");
        }

        public async Task JoinedListing(Listing lobby, User user)
        {
            await Clients.All.SendAsync("JoinedListing", lobby, user);
        }

        public async Task LeftListing(Listing lobby, User user)
        {
            await Clients.All.SendAsync("LeftListing", lobby, user);
        }

        public async Task DeleteListing(Listing lobby, User user)
        {
            await Clients.All.SendAsync("DeleteListing", lobby, user);
        }

        public async Task GameStart(Listing lobby)
        {
            await Clients.All.SendAsync("DeleteListing", lobby);
        }

        public async Task FetchUserCount()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("fetchusercount", OnlinePlayersSingleton.OnlineUsers.Count);
        }

    public async Task UserLoggedIn(Models.User user)
        {
            OnlinePlayersSingleton.OnlineUsers.Add(user);
            await Clients.All.SendAsync("UserLoggedIn", user, OnlinePlayersSingleton.OnlineUsers.Count);
        }

        public async Task UserLoggedOff(Models.User user)
        {
            await Clients.All.SendAsync("UserLoggedOff", user);
        }
    }
}