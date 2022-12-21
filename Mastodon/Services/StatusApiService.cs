using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

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
        _mastodon.SetDefaults(context);

        var result = (await _mastodon.Statuses.GetByIdAsync(request.Value))!;
        return result.ToGrpc();
    }

    public override async Task<Accounts> GetRebloggedBy(GetRebloggedByRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.GetRebloggedByAsync(request.StatusId,
            maxId: request.HasMaxId ? request.MaxId : null,
            sinceId: request.HasSinceId ? request.SinceId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null);

        return result!.ToGrpc();
    }

    public override async Task<Accounts> GetFavouritedBy(GetFavouritedByRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.GetFavouritedByAsync(request.StatusId,
            maxId: request.HasMaxId ? request.MaxId : null,
            sinceId: request.HasSinceId ? request.SinceId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null);

        await result.WriteHeadersTo(context);

        return result.Data.ToGrpc();
    }

    public override async Task<Grpc.Context> GetContext(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.GetContextAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Favourite(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.FavoriteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unfavourite(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.UnfavoriteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Bookmark(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.BookmarkAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unbookmark(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.UnbookmarkAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Mute(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.MuteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unmute(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.UnmuteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Pin(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.PinAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unpin(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.UnpinAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Status> Reblog(ReblogRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.ReblogAsync(request.StatusId, visibility: request.HasVisibility ? request.Visibility : null);

        if (!result.IsSuccessStatusCode)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Internal, result.StatusCode.ToString()));
        }

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Grpc.Status> Unreblog(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Statuses.UnreblogAsync(request.Value);
        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }
}
