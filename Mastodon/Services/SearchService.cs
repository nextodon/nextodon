namespace Mastodon.Services;

public sealed class SearchService : Mastodon.Grpc.SearchApi.SearchApiBase
{

    private readonly ILogger<SearchService> _logger;
    private readonly Data.DataContext _db;

    public SearchService(ILogger<SearchService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<Grpc.SearchResult> Search(SearchRequest request, ServerCallContext context)
    {
        return base.Search(request, context);
    }
}
