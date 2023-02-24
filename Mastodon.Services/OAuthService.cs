namespace Mastodon.Services;

public sealed class OAuthService : Mastodon.Grpc.OAuth.OAuthBase {
    private readonly ILogger<OAuthService> _logger;
    private readonly Data.DataContext _db;

    public OAuthService(ILogger<OAuthService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }
}
