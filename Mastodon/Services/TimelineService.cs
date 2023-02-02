using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Services;

public sealed class TimelineService : Mastodon.Grpc.Timeline.TimelineBase
{
    private readonly MastodonClient _mastodon;
    private readonly DataContext _db;
    private readonly ILogger<TimelineService> _logger;
    public TimelineService(ILogger<TimelineService> logger, MastodonClient mastodon, DataContext db)
    {
        _logger = logger;
        _mastodon = mastodon;
        _db = db;
    }

    public override async Task<Grpc.Statuses> GetPublic(GetPublicTimelineRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetPublicAsync(
            local: request.Local,
            remote: request.Remote,
            onlyMedia: request.OnlyMedia,
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null
            );

        await result.WriteHeadersTo(context);

        var ret = result.Data.ToGrpc();

        await ret.GetPolls(_db);

        return ret;
    }

    public override async Task<Statuses> GetByTag(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetTagAsync(request.Value);

        var ret = result.ToGrpc();

        await ret.GetPolls(_db);

        return ret;
    }

    public override async Task<Statuses> GetHome(DefaultPaginationParameters request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetHomeAsync(
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null
        );

        var ret = result.ToGrpc();

        await ret.GetPolls(_db);

        return ret;
    }

    public override async Task<Statuses> GetList(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetListAsync(request.Value);
        var ret = result.ToGrpc();

        await ret.GetPolls(_db);

        return ret;
    }

#pragma warning disable CS0809
    [Obsolete]
    public override async Task<Statuses> GetDirect(DefaultPaginationParameters request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetDirectAsync(
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null
        );

        var ret = result.ToGrpc();

        await ret.GetPolls(_db);

        return ret;
    }
#pragma warning restore CS0809
}
