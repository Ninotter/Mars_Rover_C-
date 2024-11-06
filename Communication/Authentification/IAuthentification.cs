namespace Communication.Authentification
{
    public interface IAuthentification
    {
        TokenAuthentication CreateToken(CredentialsInfo credentials);

        AuthenticationResponse VerifyToken(TokenAuthentication token);
    }
}
