using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class TestHub:Hub
    {
        public static List<string> clients=new List<string>();
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("ReceivedMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            //loglama ucun en elverisli variyantdir
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}
