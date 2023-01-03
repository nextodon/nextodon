using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Grpc;
using Microsoft.Extensions.Logging;

namespace Mastodon.Services;

public sealed class PollApiService : Mastodon.Grpc.PollApi.PollApiBase
{
    private readonly ILogger<PollApiService> _logger;
    private readonly Data.DataContext _db;

    public PollApiService(ILogger<PollApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }
}
