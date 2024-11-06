namespace Communication.Authentification
{
    public interface IAuthentification
    {
        TokenAuthentication CreateToken(SecretCredentialsInfo credentials);

        AuthenticationResponse VerifyToken(TokenAuthentication token);
    }
}
