namespace Mastodon.Services;

[Authorize]
[AllowAnonymous]
public sealed class TimelineService : Mastodon.Grpc.Timeline.TimelineBase {
    private readonly MastodonClient _mastodon;
    private readonly DataContext _db;
    private readonly ILogger<TimelineService> _logger;
    public TimelineService(ILogger<TimelineService> logger, MastodonClient mastodon, DataContext db) {
        _logger = logger;
        _mastodon = mastodon;
        _db = db;
    }

    public override async Task<Grpc.Statuses> GetPublic(GetPublicTimelineRequest request, ServerCallContext context) {
        var userId = context.GetAccountId(false);

        var local = request.Local;
        var remote = request.Remote;
        var onlyMedia = request.OnlyMedia;
        var sinceId = request.HasSinceId ? request.SinceId : null;
        var maxId = request.HasMaxId ? request.MaxId : null;
        var minId = request.HasMinId ? request.MinId : null;

        if (local) {
            var limit = request.HasLimit ? request.Limit : 40;
            var filter = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);

            var sort = Builders<Data.Status>.Sort.Descending(x => x.CreatedAt);

            if (!string.IsNullOrWhiteSpace(maxId)) {
                filter &= Builders<Data.Status>.Filter.Lt(x => x.Id, maxId);
            }

            var cursor = await _db.Status.FindAsync(filter, new FindOptions<Data.Status, Data.Status> { Limit = (int)limit, Sort = sort });
            var statuses = await cursor.ToListAsync();

            var v = new Grpc.Statuses();
            foreach (var status in statuses) {
                var s = await _db.GetStatusById(context, _mastodon, status.Id, userId);
                v.Data.Add(s);
            }

            return v;
        }

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

        return ret;
    }

    public override async Task<Statuses> GetByTag(StringValue request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetTagAsync(request.Value);

        var ret = result.ToGrpc();

        return ret;
    }

    public override async Task<Statuses> GetHome(DefaultPaginationParameters request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetHomeAsync(
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null
        );

        var ret = result.ToGrpc();

        return ret;
    }

    public override async Task<Statuses> GetList(StringValue request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetListAsync(request.Value);
        var ret = result.ToGrpc();

        return ret;
    }

#pragma warning disable CS0809
    [Obsolete]
    public override async Task<Statuses> GetDirect(DefaultPaginationParameters request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Timeline.GetDirectAsync(
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null
        );

        var ret = result.ToGrpc();

        return ret;
    }
#pragma warning restore CS0809
}
