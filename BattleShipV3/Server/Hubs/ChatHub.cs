using Microsoft.AspNetCore.SignalR;

namespace BattleShipV3.Server.Hubs
{

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}