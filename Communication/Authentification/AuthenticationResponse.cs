namespace Communication.Authentification
{
    public class AuthenticationResponse(bool isSuccessful)
    {
        bool IsSuccessful { get; } = isSuccessful;
    }
}