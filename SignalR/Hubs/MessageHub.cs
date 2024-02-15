using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class MessageHub:Hub
    {

        public const string GroupName="p134";
        public async Task SendMessageAsync(string message,IEnumerable<string> connectionIDs)
        {
           

            #region CallerType
            //Callerde sadece hansi client servere baglanibsa mesajida ozu alir ancaq 
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            //All typde server uzerindeki butun userlere gedir
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Others
            //Othersde servere msj gonderenden baska herkese gonderilir
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion


            #region AllExcept
            //Secilen clientlar xaric butun klientlara gonderir
            //await Clients.AllExcept(connectionIDs).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            //Secilen clientla  gonderir
           // await Clients.Clients(connectionIDs).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            //Secilen clientlara  gonderir
            //await Clients.Clients(connectionIDs).SendAsync("receiveMessage", message);
            #endregion

            #region Group
            //Secilen qrupdaki clientlara gonderir
            //await Clients.Group(GroupName).SendAsync("receiveMessage", message);
            #endregion

            #region AllExcept
            //Secilen clientlar xaric butun klientlara gonderir
            await Clients.AllExcept(connectionIDs).SendAsync("receiveMessage", message);
            #endregion
        }


        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
