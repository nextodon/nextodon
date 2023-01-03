using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Grpc;
using Microsoft.Extensions.Logging;

namespace Mastodon.Services;

public sealed class SearchApiService : Mastodon.Grpc.SearchApi.SearchApiBase
{
    private readonly ILogger<SearchApiService> _logger;
    private readonly Data.DataContext _db;

    public SearchApiService(ILogger<SearchApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }
}
