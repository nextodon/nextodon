namespace Mastodon.Services;

public sealed class OAuthService : Mastodon.Grpc.OAuth.OAuthBase {
    private readonly MastodonClient _mastodon;
    private readonly ILogger<OAuthService> _logger;

    public OAuthService(ILogger<OAuthService> logger, MastodonClient mastodon) {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Token> ObtainToken(ObtainTokenRequest request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.OAuth.ObtainTokenAsync(
           grantType: request.GrantType,
           clientId: request.ClientId,
           clientSecret: request.ClientSecret,
           redirectUri: request.RedirectUri,
           code: request.Code,
           scope: request.Scope);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }
}
