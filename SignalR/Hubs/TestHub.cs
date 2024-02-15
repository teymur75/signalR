using Microsoft.AspNetCore.SignalR;
using SignalR.Interfaces;

namespace SignalR.Hubs
{
    public class TestHub:Hub<IClientMethods>
    {
        public static List<string> clients=new List<string>();
        public override async Task OnConnectedAsync()
        {
            //loglama ucun en elverisli variyantdir
            clients.Add(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);

            await Clients.All.clients(clients);
            await Clients.All.userJoined(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeft", Context.ConnectionId);
            await Clients.All.clients(clients);
            await Clients.All.userLeft(Context.ConnectionId);
        }
    }
}
