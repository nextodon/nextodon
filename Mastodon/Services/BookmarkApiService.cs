using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Services;

public sealed class BookmarkApiService : Mastodon.Grpc.BookmarkApi.BookmarkApiBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<BookmarkApiService> _logger;
    public BookmarkApiService(ILogger<BookmarkApiService> logger, MastodonClient mastodon)
    {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Statuses> GetBookmarks(GetBookmarksRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Bookmark.GetBookmarksAsync(
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data.ToGrpc();
    }
}
