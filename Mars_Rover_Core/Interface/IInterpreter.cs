namespace Mars_Rover.Core.Interface
{
    public interface IInterpreter
    {
        Task Send(string command);
    }
}