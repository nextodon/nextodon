using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Services;

public sealed class DirectoryService : Mastodon.Grpc.Directory.DirectoryBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<DirectoryService> _logger;
    public DirectoryService(ILogger<DirectoryService> logger, MastodonClient mastodon)
    {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Accounts> GetAccounts(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Directory.GetDirectoryAsync());
        return result.ToGrpc();
    }
}
