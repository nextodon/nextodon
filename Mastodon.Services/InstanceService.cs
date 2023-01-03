using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Grpc;
using Microsoft.Extensions.Logging;

namespace Mastodon.Services;

public sealed class InstanceService : Mastodon.Grpc.InstanceApi.InstanceApiBase
{
    private readonly ILogger<InstanceService> _logger;
    private readonly Data.DataContext _db;

    public InstanceService(ILogger<InstanceService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }
}
