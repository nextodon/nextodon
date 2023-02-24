namespace Mastodon.Services;

public sealed class MediaApiService : Mastodon.Grpc.MediaApi.MediaApiBase {

    private readonly ILogger<MediaApiService> _logger;
    private readonly Data.DataContext _db;

    public MediaApiService(ILogger<MediaApiService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }

    public override Task<MediaAttachment> GetMedia(StringValue request, ServerCallContext context) {
        return base.GetMedia(request, context);
    }
}
