namespace Mastodon.Services;

public sealed class AppsService : Mastodon.Grpc.Apps.AppsBase
{
    private readonly ILogger<AppsService> _logger;
    private readonly Data.DataContext _db;

    public AppsService(ILogger<AppsService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }
}
