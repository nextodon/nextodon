namespace Mastodon.Services;

[Authorize]
public sealed class StatusApiService : Mastodon.Grpc.StatusApi.StatusApiBase {

    private readonly ILogger<StatusApiService> _logger;
    private readonly Data.DataContext _db;

    public StatusApiService(ILogger<StatusApiService> logger, DataContext db) {
        _logger = logger;
        _db = db;
    }

    [AllowAnonymous]
    public override async Task<Grpc.Status> GetStatus(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(false);
        var statusId = request.Value;

        var filter = Builders<Data.Status>.Filter.Eq(x => x.Id, statusId);
        var ret = await _db.GetStatusById(context, statusId, accountId);

        return ret;
    }

    [AllowAnonymous]
    public override async Task<Accounts> GetRebloggedBy(GetRebloggedByRequest request, ServerCallContext context) {
        //var accountId = context.GetAccountId(false);
        var statusId = request.StatusId;

        IMongoQueryable<string> q = from x in _db.Status.AsQueryable()
                                    where x.ReblogedFromId == statusId
                                    select x.AccountId;

        var accountIds = await q.ToListAsync();
        var distinct = accountIds.Distinct();
        var result = await _db.Account.FindByIdsAsync(distinct);

        return result.ToGrpc();
    }

    [AllowAnonymous]
    public override async Task<Accounts> GetFavouritedBy(GetFavouritedByRequest request, ServerCallContext context) {
        var accountId = context.GetAccountId(false);
        var statusId = request.StatusId;

        IMongoQueryable<string> q = from x in _db.StatusAccount.AsQueryable()
                                    where x.StatusId == statusId && x.Favorite
                                    select x.AccountId;

        var accountIds = await q.ToListAsync();
        var distinct = accountIds.Distinct();
        var result = await _db.Account.FindByIdsAsync(distinct);

        return result.ToGrpc();
    }

    [AllowAnonymous]
    public override async Task<Grpc.Context> GetContext(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(false);

        var ctx = new Grpc.Context();

        var theStatus = await _db.Status.FindByIdAsync(request.Value);

        if (!string.IsNullOrEmpty(theStatus!.InReplyToId)) {
            IMongoQueryable<string> q = from x in _db.Status.AsQueryable()
                                        where x.Id == theStatus.InReplyToId
                                        select x.Id;

            var ancestorsIds = await q.ToListAsync();

            foreach (var statusId in ancestorsIds) {
                var status = await _db.GetStatusById(context, statusId, accountId);
                ctx.Ancestors.Add(status);
            }
        }
        {
            IMongoQueryable<string> q = from x in _db.Status.AsQueryable()
                                        where x.InReplyToId == request.Value
                                        select x.Id;

            var descendantIds = await q.ToListAsync();

            foreach (var statusId in descendantIds) {
                var status = await _db.GetStatusById(context, statusId, accountId);
                ctx.Descendants.Add(status);
            }
        }

        return ctx;
    }

    public override async Task<Grpc.Status> CreateStatus(CreateStatusRequest request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);

        var status = new Data.Status {
            AccountId = accountId!,
            Text = request.Status,
            CreatedAt = DateTime.UtcNow,
            Visibility = Data.Visibility.Public,
            MediaIds = request.MediaIds?.ToList(),
            Sensitive = request.Sensitive,
            Poll = request.Poll?.ToData(),
            Language = request.HasLanguage ? request.Language : null,
            SpoilerText = request.HasSpoilerText ? request.SpoilerText : null,
            InReplyToId = request.HasInReplyToId ? request.InReplyToId : null,
            ReblogedFromId = null,
            Deleted = false,
        };

        await _db.Status.InsertOneAsync(status);

        var result = await _db.GetStatusById(context, status.Id, accountId);

        return result;
    }

    public override async Task<Grpc.Status> DeleteStatus(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        {
            var filter = Builders<Data.Status>.Filter.Eq(x => x.Id, statusId);
            var update = Builders<Data.Status>.Update.Set(x => x.Deleted, true);

            await _db.Status.UpdateOneAsync(filter, update);
        }

        {
            var filter = Builders<Data.Status_Account>.Filter.Eq(x => x.StatusId, statusId);
            var update = Builders<Data.Status_Account>.Update.Set(x => x.Deleted, true);

            await _db.StatusAccount.UpdateManyAsync(filter, update);
        }

        return new Grpc.Status { Id = statusId };
    }

    public override async Task<Grpc.Status> Favourite(StringValue request, ServerCallContext context) {
        var cancellationToken = context.CancellationToken;
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, favorite: true, cancellationToken: cancellationToken);

        var result = await _db.GetStatusById(context, statusId, accountId);
        return result;

    }

    public override async Task<Grpc.Status> Unfavourite(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, favorite: false);

        var result = await _db.GetStatusById(context, statusId, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Bookmark(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, bookmark: true);

        var result = await _db.GetStatusById(context, request.Value, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Unbookmark(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, bookmark: false);

        var result = await _db.GetStatusById(context, request.Value, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Mute(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, mute: true);

        var result = await _db.GetStatusById(context, request.Value, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Unmute(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, mute: false);

        var result = await _db.GetStatusById(context, request.Value, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Pin(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, pin: true);

        var result = await _db.GetStatusById(context, request.Value, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Unpin(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;

        await _db.StatusAccount.UpdateAsync(statusId, accountId!, pin: false);

        // Return.
        var result = await _db.GetStatusById(context, request.Value, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Reblog(ReblogRequest request, ServerCallContext context) {

        var accountId = context.GetAccountId(true);
        var statusId = request.StatusId;

        var oldStatus = await _db.Status.FindByIdAsync(statusId);

        if (oldStatus == null) {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty));
        }

        var status = new Data.Status {
            Text = oldStatus.Text,
            CreatedAt = DateTime.UtcNow,
            Visibility = Mastodon.Data.Visibility.Public,
            MediaIds = oldStatus.MediaIds,
            Sensitive = oldStatus.Sensitive,
            Poll = oldStatus.Poll,
            AccountId = accountId!,
            ReblogedFromId = oldStatus.ReblogedFromId ?? request.StatusId,
            Language = oldStatus.Language,
            SpoilerText = oldStatus.SpoilerText,
            InReplyToId = oldStatus.InReplyToId,
            Deleted = false,
        };

        await _db.Status.InsertOneAsync(status);

        // Return.
        var result = await _db.GetStatusById(context, status.Id, accountId);
        return result;
    }

    public override async Task<Grpc.Status> Unreblog(StringValue request, ServerCallContext context) {
        var accountId = context.GetAccountId(true);
        var statusId = request.Value;
        IMongoQueryable<string> q = from x in _db.Status.AsQueryable()
                                    where x.AccountId == accountId
                                    where x.ReblogedFromId == statusId
                                    select x.Id;

        var reblogs = await q.ToListAsync();

        {
            var filter = Builders<Data.Status>.Filter.In(x => x.Id, reblogs);
            var update = Builders<Data.Status>.Update.Set(x => x.Deleted, true);

            await _db.Status.UpdateManyAsync(filter, update);
        }

        {
            var filter = Builders<Data.Status_Account>.Filter.In(x => x.StatusId, reblogs);
            var update = Builders<Data.Status_Account>.Update.Set(x => x.Deleted, true);

            await _db.StatusAccount.UpdateManyAsync(filter, update);
        }

        var result = await _db.GetStatusById(context, statusId, accountId);
        return result;
    }
}
