namespace Mastodon.Services;

public sealed class TrendsService : Mastodon.Grpc.Trends.TrendsBase {
    private readonly ILogger<TrendsService> _logger;
    private readonly Data.DataContext _db;

    public TrendsService(ILogger<TrendsService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }
}
