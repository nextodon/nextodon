namespace Nextodon.Services;

public sealed class SearchService : Nextodon.Grpc.SearchApi.SearchApiBase
{

    private readonly ILogger<SearchService> _logger;
    private readonly MastodonContext _db;

    public SearchService(ILogger<SearchService> logger, MastodonContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<Grpc.SearchResult> Search(SearchRequest request, ServerCallContext context)
    {
        return base.Search(request, context);
    }
}
