namespace Mastodon.Services;

public sealed class TimelineApiService : Mastodon.Grpc.Timeline.TimelineBase {
    private readonly ILogger<TimelineApiService> _logger;
    private readonly Data.DataContext _db;

    public TimelineApiService(ILogger<TimelineApiService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }
}
