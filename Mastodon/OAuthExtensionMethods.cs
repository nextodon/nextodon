namespace Mastodon;

public static class OAuthExtensionMethods
{
    public static Grpc.Token ToGrpc(this Mastodon.Models.Token i)
    {
        var v = new Grpc.Token
        {
            AccessToken = i.AccessToken,
            CreatedAt = i.CreatedAt,
            Scope = i.Scope,
            TokenType = i.TokenType,
        };

        return v;
    }
}
