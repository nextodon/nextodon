namespace Mastodon.Services;

[Authorize]
public sealed class MarkerService : Mastodon.Grpc.MarkerApi.MarkerApiBase
{

    private readonly ILogger<MarkerService> _logger;
    private readonly Data.DataContext _db;

    public MarkerService(ILogger<MarkerService> logger, DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override async Task<Grpc.Marker> Get(GetMarkerRequest request, ServerCallContext context)
    {
        var accountId = context.GetAccountId(true);

        var filter = Builders<Data.Marker>.Filter.Eq(x => x.AccountId, accountId);
        var update = Builders<Data.Marker>.Update
            .SetOnInsert(x => x.AccountId, accountId)
            .SetOnInsert(x => x.Home, null)
            .SetOnInsert(x => x.Notifications, null);

        var marker = await _db.Marker.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Data.Marker, Data.Marker> { IsUpsert = true, ReturnDocument = ReturnDocument.After });

        return marker.ToGrpc();
    }

    public override async Task<Grpc.Marker> Set(SetMarkerRequest request, ServerCallContext context)
    {
        var accountId = context.GetAccountId(true);

        var filter = Builders<Data.Marker>.Filter.Eq(x => x.AccountId, accountId);
        var update = Builders<Data.Marker>.Update
            .SetOnInsert(x => x.AccountId, accountId)
            .SetOnInsert(x => x.Home, null)
            .SetOnInsert(x => x.Notifications, null);

        var marker = await _db.Marker.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Data.Marker, Data.Marker> { IsUpsert = true, ReturnDocument = ReturnDocument.After });

        var now = DateTime.UtcNow;

        if (request.Home != null && !string.IsNullOrWhiteSpace(request.Home.LastReadId))
        {
            if (marker.Home == null)
            {
                var u = Builders<Data.Marker>.Update.Set(x => x.Home, new Data.Marker.MarkerItem { LastReadId = request.Home.LastReadId, Version = 1, UpdatedAt = now });
                marker = await _db.Marker.FindOneAndUpdateAsync(filter, u, new FindOneAndUpdateOptions<Data.Marker, Data.Marker> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            }
            else
            {
                var u = Builders<Data.Marker>.Update
                    .Set(x => x.Home!.LastReadId, request.Home.LastReadId)
                    .Inc(x => x.Home!.Version, 1u)
                    .Set(x => x.Home!.UpdatedAt, now);

                marker = await _db.Marker.FindOneAndUpdateAsync(filter, u, new FindOneAndUpdateOptions<Data.Marker, Data.Marker> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            }
        }

        if (request.Notifications != null && !string.IsNullOrWhiteSpace(request.Notifications.LastReadId))
        {
            if (marker.Notifications == null)
            {
                var u = Builders<Data.Marker>.Update.Set(x => x.Notifications, new Data.Marker.MarkerItem { LastReadId = request.Notifications.LastReadId, Version = 1, UpdatedAt = now });
                marker = await _db.Marker.FindOneAndUpdateAsync(filter, u, new FindOneAndUpdateOptions<Data.Marker, Data.Marker> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            }
            else
            {
                var u = Builders<Data.Marker>.Update
                    .Set(x => x.Notifications!.LastReadId, request.Notifications.LastReadId)
                    .Inc(x => x.Notifications!.Version, 1u)
                    .Set(x => x.Notifications!.UpdatedAt, now);

                marker = await _db.Marker.FindOneAndUpdateAsync(filter, u, new FindOneAndUpdateOptions<Data.Marker, Data.Marker> { IsUpsert = true, ReturnDocument = ReturnDocument.After });
            }
        }

        return marker.ToGrpc();
    }
}
