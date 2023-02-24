namespace Mastodon.Services;

public sealed class DirectoryService : Mastodon.Grpc.Directory.DirectoryBase {
    private readonly ILogger<DirectoryService> _logger;
    private readonly Data.DataContext _db;

    public DirectoryService(ILogger<DirectoryService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }
}
