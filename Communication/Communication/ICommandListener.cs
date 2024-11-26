namespace Communication.Communication
{
    public interface ICommandListener<T>
    {
        void Subscribe(Func<string, T> resultingAction);
    }
}
