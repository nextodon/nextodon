namespace Nextodon.Services;

public sealed class AccountApiService : Nextodon.Grpc.AccountApi.AccountApiBase
{

    private readonly ILogger<AccountApiService> _logger;
    private readonly Data.DataContext _db;

    public AccountApiService(ILogger<AccountApiService> logger, DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    [Authorize]
    public override async Task<Grpc.Account> UpdateCredentials(UpdateCredentialsRequest request, ServerCallContext context)
    {
        var host = context.GetHost();
        var accountId = context.GetAccountId(true);

        var filter = Builders<Data.Account>.Filter.Eq(x => x.Id, accountId);
        var updates = new List<UpdateDefinition<Data.Account>>();

        if (request.HasBot)
        {
            var u = Builders<Data.Account>.Update.Set(x => x.Bot, request.Bot);
            updates.Add(u);
        }

        if (request.HasLocked)
        {
            var u = Builders<Data.Account>.Update.Set(x => x.Locked, request.Locked);
            updates.Add(u);
        }

        if (request.HasNote)
        {
            var u = Builders<Data.Account>.Update.Set(x => x.Note, request.Note);
            updates.Add(u);
        }

        if (request.HasDiscoverable)
        {
            var u = Builders<Data.Account>.Update.Set(x => x.Discoverable, request.Discoverable);
            updates.Add(u);
        }

        if (request.HasDisplayName)
        {
            var u = Builders<Data.Account>.Update.Set(x => x.DisplayName, request.DisplayName);
            updates.Add(u);
        }

        //if (request.Ha) {
        //    var u = Builders<Data.Account>.Update.Set(x => x.DisplayName, request.DisplayName);
        //    updates.Add(u);
        //}

        var update = Builders<Data.Account>.Update.Combine(updates);

        var account = await _db.Account.FindOneAndUpdateAsync(filter, update);

        return account.ToGrpc(host);
    }

    public override async Task<Grpc.Account> GetById(StringValue request, ServerCallContext context)
    {
        var host = context.GetHost();
        var account = await _db.Account.FindByIdAsync(request.Value);

        return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc(host);
    }

    /// <summary>
    /// Lookup account ID from Webfinger address.
    /// <br />
    /// Quickly lookup a username to see if it is available, skipping WebFinger resolution.
    /// </summary>
    public override Task<Grpc.Account> Lookup(LookupRequest request, ServerCallContext context)
    {
        return base.Lookup(request, context);
    }

    public override Task<Accounts> Search(AccountSearchRequest request, ServerCallContext context)
    {
        return base.Search(request, context);
    }

    [Authorize]
    public override async Task<Grpc.Account> VerifyCredentials(Empty request, ServerCallContext context)
    {
        var host = context.GetHost();
        var account = await context.GetAccount(_db, true);
        return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc(host);
    }

    [Authorize]
    [AllowAnonymous]
    public override async Task<Statuses> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        var me = context.GetAccountId(true);

        var limit = request.HasLimit ? request.Limit : 40;
        limit = Math.Min(limit, 80);

        var onlyMedia = request.OnlyMedia;
        var sinceId = request.HasSinceId ? request.SinceId : null;
        var maxId = request.HasMaxId ? request.MaxId : null;
        var minId = request.HasMinId ? request.MinId : null;

        var sort = Builders<Data.Status>.Sort.Descending(x => x.CreatedAt);

        var filters = new List<FilterDefinition<Data.Status>>
        {
            Builders<Data.Status>.Filter.Eq(x => x.AccountId, request.AccountId),
            Builders<Data.Status>.Filter.Ne(x => x.Deleted, true),
        };


        if (!string.IsNullOrWhiteSpace(maxId))
        {
            filters.Add(Builders<Data.Status>.Filter.Gt(x => x.Id, maxId));
        }

        if (!string.IsNullOrWhiteSpace(minId))
        {
            filters.Add(Builders<Data.Status>.Filter.Lt(x => x.Id, minId));
        }

        var options = new FindOptions<Data.Status, Data.Status> { Limit = (int)limit };

        var filter = Builders<Data.Status>.Filter.And(filters);
        var cursor = await _db.Status.FindAsync(filter, options);
        var statuses = await cursor.ToListAsync();

        var v = new Statuses();

        foreach (var status in statuses)
        {
            try
            {
                var s = await _db.GetStatusById(context, status.Id, me, true);
                v.Data.Add(s);
            }
            catch { }
        }

        return v;
    }

    [Authorize]
    public override async Task<Statuses> GetFavourites(DefaultPaginationParameters request, ServerCallContext context)
    {

        var accountId = context.GetAccountId(true);

        IMongoQueryable<string> q = from x in _db.StatusAccount.AsQueryable()
                                    where x.AccountId == accountId
                                    where x.Deleted != true
                                    where x.Favorite == true
                                    select x.StatusId;

        var ids = await q.ToListAsync();
        var v = new Statuses();

        foreach (var id in ids)
        {
            try
            {
                var status = await _db.GetStatusById(context, id, accountId, true);
                v.Data.Add(status);
            }
            catch { }
        }

        return v;
    }

    public override Task<Tags> GetFollowedTags(DefaultPaginationParameters request, ServerCallContext context)
    {
        var v = new Tags();

        return Task.FromResult(v);
    }

    public override Task<Preferences> GetPreferences(Empty request, ServerCallContext context)
    {
        var v = new Preferences();

        return Task.FromResult(v);
    }

    public override Task<FiltersV1> GetFilters(Empty request, ServerCallContext context)
    {
        var v = new FiltersV1();

        return Task.FromResult(v);
    }

    public override Task<FeaturedTags> GetFeaturedTags(Empty request, ServerCallContext context)
    {
        var v = new FeaturedTags();

        return Task.FromResult(v);
    }

    public override Task<Accounts> GetFollowers(GetFollowersRequest request, ServerCallContext context)
    {
        return base.GetFollowers(request, context);
    }

    public override Task<Accounts> GetFollowing(GetFollowingRequest request, ServerCallContext context)
    {
        return base.GetFollowing(request, context);
    }

    public override Task<Grpc.Relationship> RemoveFromFollowers(StringValue request, ServerCallContext context)
    {
        return base.RemoveFromFollowers(request, context);
    }

    [Authorize]
    public override async Task<Relationships> GetRelationships(GetRelationshipsRequest request, ServerCallContext context)
    {
        var accountId = context.GetAccountId(true);
        var ids = request.Ids.ToArray();

        var v = new Relationships();

        foreach (var id in ids)
        {
            var filter1 = Builders<Data.Relationship>.Filter.Eq(x => x.From, accountId);
            var filter2 = Builders<Data.Relationship>.Filter.Eq(x => x.To, id);

            var filter = filter1 & filter2;
            var update = Builders<Data.Relationship>.Update.SetOnInsert(x => x.From, accountId).SetOnInsert(x => x.To, id);

            var relationship = await _db.Relationship.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Data.Relationship, Data.Relationship> { IsUpsert = true });

            v.Data.Add(new Grpc.Relationship { Id = id, Note = relationship?.Note ?? string.Empty });
        }

        return v;
    }

    public override Task<Lists> GetLists(StringValue request, ServerCallContext context)
    {
        return base.GetLists(request, context);
    }

    public override Task<Grpc.Relationship> Follow(StringValue request, ServerCallContext context)
    {
        return base.Follow(request, context);
    }

    public override Task<Grpc.Relationship> Unfollow(StringValue request, ServerCallContext context)
    {
        return base.Unfollow(request, context);
    }

    public override Task<Grpc.Relationship> Block(StringValue request, ServerCallContext context)
    {
        return base.Block(request, context);
    }

    public override Task<Grpc.Relationship> Unblock(StringValue request, ServerCallContext context)
    {
        return base.Unblock(request, context);
    }

    public override Task<Grpc.Relationship> Mute(StringValue request, ServerCallContext context)
    {
        return base.Mute(request, context);
    }

    public override Task<Grpc.Relationship> Unmute(StringValue request, ServerCallContext context)
    {
        return base.Unmute(request, context);
    }

    public override Task<Grpc.Relationship> Pin(StringValue request, ServerCallContext context)
    {
        return base.Pin(request, context);
    }

    public override Task<Grpc.Relationship> Unpin(StringValue request, ServerCallContext context)
    {
        return base.Unpin(request, context);
    }

    /// <summary>
    /// Sets a private note on a user.
    /// </summary>
    public override Task<Grpc.Relationship> Note(NoteRequest request, ServerCallContext context)
    {
        return base.Note(request, context);
    }
}
