using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;
using Mastodon.Models;

namespace Mastodon.Services;

public sealed class StatusApiService : Mastodon.Grpc.StatusApi.StatusApiBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<StatusApiService> _logger;

    public StatusApiService(ILogger<StatusApiService> logger, MastodonClient mastodon)
    {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Grpc.Status> GetStatus(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = (await _mastodon.Statuses.GetByIdAsync(request.Value))!;
        return result.ToGrpc();
    }

    public override async Task<Grpc.Context> GetContext(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.GetContextAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Favourite(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.FavoriteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unfavourite(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.UnfavoriteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Bookmark(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.BookmarkAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unbookmark(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.UnbookmarkAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Mute(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.MuteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unmute(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Statuses.UnmuteAsync(request.Value);
        return result!.ToGrpc();
    }
}
