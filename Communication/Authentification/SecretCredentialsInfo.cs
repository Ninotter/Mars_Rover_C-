namespace Communication.Authentification
{
    public class SecretCredentialsInfo(string idToken)
    {
        string IdToken { get; } = idToken;
    }
}