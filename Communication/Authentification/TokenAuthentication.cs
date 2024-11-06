namespace Communication.Authentification
{
    public class TokenAuthentication(Guid uid, DateTime creationTime)
    {
        Guid UniqueId { get; } = uid;
        DateTime CreationTime { get; } = creationTime;
    }
}