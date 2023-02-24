namespace Mastodon.Services;

public sealed class OAuthService : Mastodon.Grpc.OAuth.OAuthBase {

    private readonly ILogger<OAuthService> _logger;
    private readonly Data.DataContext _db;

    public OAuthService(ILogger<OAuthService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }

    public override Task<Token> ObtainToken(ObtainTokenRequest request, ServerCallContext context) {

        var i = new Token {
            TokenType = request.GrantType,
            AccessToken = "0",
            CreatedAt = (uint)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds,
            Scope = request.Scope,
        };

        return Task.FromResult(i);
    }
}
