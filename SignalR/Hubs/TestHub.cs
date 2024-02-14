using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class TestHub:Hub
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("ReceivedMessage", message);
        }
    }
}
