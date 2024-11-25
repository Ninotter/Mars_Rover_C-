namespace Communication.Communication
{
    public interface IProtocolCommunication
    {
        Task ConnectAsync(string ipAddress, int port);

        Task DisconnectAsync();
    }
}