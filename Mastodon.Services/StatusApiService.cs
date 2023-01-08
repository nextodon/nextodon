namespace Mastodon.Services;

public sealed class StatusApiService : Mastodon.Grpc.StatusApi.StatusApiBase
{
    private readonly ILogger<StatusApiService> _logger;
    private readonly Data.DataContext _db;

    public StatusApiService(ILogger<StatusApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }
}
