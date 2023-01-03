using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Grpc;
using Microsoft.Extensions.Logging;

namespace Mastodon.Services;

public sealed class AccountApiService : Mastodon.Grpc.AccountApi.AccountApiBase
{
    private readonly ILogger<AccountApiService> _logger;
    private readonly Data.DataContext _db;

    public AccountApiService(ILogger<AccountApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }
}
