namespace SignalR.Interfaces
{
    public interface IClientMethods
    {
        Task clients(List<string> clients);
        Task userJoined(string connectionId);
        Task userLeft(string connectionId);
    }
}
