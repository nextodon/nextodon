using Microsoft.EntityFrameworkCore;

namespace Nextodon.Services;

[Authorize]
[AllowAnonymous]
public sealed class TimelineService : Nextodon.Grpc.Timeline.TimelineBase
{

    private readonly DataContext _db;
    private readonly Data.PostgreSQL.MastodonContext _pg;
    private readonly ILogger<TimelineService> _logger;

    public TimelineService(ILogger<TimelineService> logger, DataContext db, Data.PostgreSQL.MastodonContext pg)
    {
        _logger = logger;
        _db = db;
        _pg = pg;
    }

    public override async Task<Grpc.Statuses> GetPublic(GetPublicTimelineRequest request, ServerCallContext context)
    {
        var pg = await _pg.Statuses.Take(20).ToListAsync();
        var accountId = context.GetAccountId(false);

        var local = request.Local;
        var remote = request.Remote;
        var onlyMedia = request.OnlyMedia;
        var sinceId = request.HasSinceId ? request.SinceId : null;
        var maxId = request.HasMaxId ? request.MaxId : null;
        var minId = request.HasMinId ? request.MinId : null;

        var limit = request.HasLimit ? request.Limit : 40;
        var filter = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);

        var sort = Builders<Data.Status>.Sort.Descending(x => x.CreatedAt);

        if (!string.IsNullOrWhiteSpace(maxId))
        {
            filter &= Builders<Data.Status>.Filter.Gt(x => x.Id, maxId);
        }

        if (!string.IsNullOrWhiteSpace(minId))
        {
            filter &= Builders<Data.Status>.Filter.Lt(x => x.Id, minId);
        }

        var cursor = await _db.Status.FindAsync(filter, new FindOptions<Data.Status, Data.Status> { Limit = (int)limit, Sort = sort });
        var statuses = await cursor.ToListAsync();

        var v = new Grpc.Statuses();
        foreach (var status in statuses)
        {
            var s = await _db.GetStatusById(context, status.Id, accountId);
            v.Data.Add(s);
        }

        return v;

    }

    public override Task<Statuses> GetByTag(StringValue request, ServerCallContext context)
    {
        return base.GetByTag(request, context);
    }

    public override async Task<Statuses> GetHome(DefaultPaginationParameters request, ServerCallContext context)
    {
        var accountId = context.GetAccountId(false);

        var sinceId = request.HasSinceId ? request.SinceId : null;
        var maxId = request.HasMaxId ? request.MaxId : null;
        var minId = request.HasMinId ? request.MinId : null;

        var limit = request.HasLimit ? request.Limit : 40;
        var filter = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);

        var sort = Builders<Data.Status>.Sort.Descending(x => x.CreatedAt);

        if (!string.IsNullOrWhiteSpace(maxId))
        {
            filter &= Builders<Data.Status>.Filter.Gt(x => x.Id, maxId);
        }

        if (!string.IsNullOrWhiteSpace(minId))
        {
            filter &= Builders<Data.Status>.Filter.Lt(x => x.Id, minId);
        }

        var cursor = await _db.Status.FindAsync(filter, new FindOptions<Data.Status, Data.Status> { Limit = (int)limit, Sort = sort });
        var statuses = await cursor.ToListAsync();

        var v = new Grpc.Statuses();
        foreach (var status in statuses)
        {
            var s = await _db.GetStatusById(context, status.Id, accountId);
            v.Data.Add(s);
        }

        return v;
    }

    public override Task<Statuses> GetList(StringValue request, ServerCallContext context)
    {
        return base.GetList(request, context);
    }

#pragma warning disable CS0809
    [Obsolete]
    public override Task<Statuses> GetDirect(DefaultPaginationParameters request, ServerCallContext context)
    {
        return base.GetDirect(request, context);
    }
#pragma warning restore CS0809
}
