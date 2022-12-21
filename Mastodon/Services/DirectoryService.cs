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

    public override async Task<Accounts> GetAccounts(GetDirectoryRequest request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var link = context.GetHttpContext().Request.Headers["link"].ToString();
        context.ResponseTrailers.Add("link", link);

        var result = await _mastodon.Directory.GetDirectoryAsync(
            offset: request.HasOffset ? request.Offset : null,
            limit: request.HasLimit ? request.Limit : null,
            order: request.HasOrder ? request.Order : null,
            local: request.HasLocal ? request.Local : null);

        return result.ToGrpc();
    }
}
