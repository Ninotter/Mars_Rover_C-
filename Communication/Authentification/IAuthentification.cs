namespace Communication.Authentification
{
    public interface IAuthentification
    {
        TokenAuthentication CreateToken(TokenAuthenticationBuilder builder);

        AuthenticationResponse VerifyToken(TokenAuthentication token);
    }
}
