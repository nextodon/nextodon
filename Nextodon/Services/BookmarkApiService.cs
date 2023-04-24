namespace Nextodon.Services;

public sealed class BookmarkApiService : Nextodon.Grpc.BookmarkApi.BookmarkApiBase
{

    private readonly ILogger<BookmarkApiService> _logger;
    private readonly MastodonContext _db;

    public BookmarkApiService(ILogger<BookmarkApiService> logger, MastodonContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<Statuses> GetBookmarks(GetBookmarksRequest request, ServerCallContext context)
    {
        return base.GetBookmarks(request, context);
    }
}
