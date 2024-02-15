using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.Business
{
    public class TestBusiness
    {
        readonly IHubContext<TestHub> _hubContext;

        public TestBusiness(IHubContext<TestHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceivedMessage", message);
        }
    }
}
