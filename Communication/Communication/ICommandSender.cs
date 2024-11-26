namespace Communication.Communication
{
    public interface ICommandSender
    {
        Task SendCommandAsync(string action);
    }
}