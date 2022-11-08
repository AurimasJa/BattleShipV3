using BattleShipV3.Client.DesignPatterns.Singleton;
using BattleShipV3.Models;
using Microsoft.AspNetCore.SignalR;

namespace BattleShipV3.Server.Hubs
{

    public class LobbyHub : Hub
    {
        public async Task CreateListing(Listing lobby, Models.User user)
        {
            OnlinePlayersSingleton.LiveListings.TryAdd(lobby.Id, lobby);
            await Clients.All.SendAsync("CreateListing", lobby, user);
        }

        public async Task AlertObservers(Listing listing, List<string> connectionStrings)
        {
            foreach (var item in connectionStrings)
            {
                await Clients.Client(item).SendAsync("Observation", listing);
            }
        }

        public async Task JoinLobby(int lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId.ToString());
        }

        public async Task MoveToGameMatch(int lobbyId)
        {
            RemoveListingFromSingleton(lobbyId);
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
            RemoveListingFromSingleton(lobby.Id);
            await Clients.All.SendAsync("DeleteListing", lobby, user);
        }

        public async Task GameStart(Listing lobby)
        {
            RemoveListingFromSingleton(lobby.Id);
            await Clients.All.SendAsync("DeleteListing", lobby);
        }

        private void RemoveListingFromSingleton(int listingId)
        {
            Listing outL = new Listing(); ;
            OnlinePlayersSingleton.LiveListings.Remove(listingId, out outL);
        }

        public async Task FetchUserCount()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("fetchusercount", OnlinePlayersSingleton.OnlineUsers.Count);
        }

        public async Task AttachObserver(string connectionString)
        {

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