namespace Mastodon.Services;

public sealed class SearchService : Mastodon.Grpc.SearchApi.SearchApiBase {
    private readonly MastodonClient _mastodon;
    private readonly ILogger<SearchService> _logger;

    public SearchService(ILogger<SearchService> logger, MastodonClient mastodon) {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Grpc.SearchResult> Search(SearchRequest request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Search.Search(
            q: request.Q,
            type: request.HasType ? request.Type : null,
            resolve: request.HasResolve ? request.Resolve : null,
            following: request.HasFollowing ? request.Following : null,
            accountId: request.HasAccountId ? request.AccountId : null,
            excludeUnreviewed: request.HasExcludeUnreviewed ? request.ExcludeUnreviewed : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null,
            offset: request.HasOffset ? request.Offset : null
            );

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }
}
