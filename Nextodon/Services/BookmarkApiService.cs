namespace Nextodon.Services;

public sealed class BookmarkApiService : Nextodon.Grpc.BookmarkApi.BookmarkApiBase
{

    private readonly ILogger<BookmarkApiService> _logger;
    private readonly Data.DataContext _db;

    public BookmarkApiService(ILogger<BookmarkApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<Statuses> GetBookmarks(GetBookmarksRequest request, ServerCallContext context)
    {
        return base.GetBookmarks(request, context);
    }
}
