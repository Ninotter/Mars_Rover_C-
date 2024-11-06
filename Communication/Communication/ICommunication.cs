namespace Communication.Communication
{
    public interface ICommunication
    {
        void Send(string message);
        string Receive();
    }
}
