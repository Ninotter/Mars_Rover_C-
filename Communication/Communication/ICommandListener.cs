namespace Communication.Communication
{
    public interface ICommandListener
    {
        void Subscribe(Action<string> resultingAction);
    }
}
