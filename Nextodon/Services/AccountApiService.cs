namespace Nextodon.Services;

public sealed class AccountApiService : Nextodon.Grpc.AccountApi.AccountApiBase
{
    private readonly ILogger<AccountApiService> _logger;
    private readonly MastodonContext _pg;

    public AccountApiService(ILogger<AccountApiService> logger, Data.PostgreSQL.MastodonContext db)
    {
        _logger = logger;
        _pg = db;
    }

    //[Authorize]
    //public override async Task<Grpc.Account> UpdateCredentials(UpdateCredentialsRequest request, ServerCallContext context)
    //{
    //    var host = context.GetHost();
    //    var accountId = context.GetAuthToken(true);

    //    var filter = Builders<Data.Account>.Filter.Eq(x => x.Id, accountId);
    //    var updates = new List<UpdateDefinition<Data.Account>>();

    //    if (request.HasBot)
    //    {
    //        var u = Builders<Data.Account>.Update.Set(x => x.Bot, request.Bot);
    //        updates.Add(u);
    //    }

    //    if (request.HasLocked)
    //    {
    //        var u = Builders<Data.Account>.Update.Set(x => x.Locked, request.Locked);
    //        updates.Add(u);
    //    }

    //    if (request.HasNote)
    //    {
    //        var u = Builders<Data.Account>.Update.Set(x => x.Note, request.Note);
    //        updates.Add(u);
    //    }

    //    if (request.HasDiscoverable)
    //    {
    //        var u = Builders<Data.Account>.Update.Set(x => x.Discoverable, request.Discoverable);
    //        updates.Add(u);
    //    }

    //    if (request.HasDisplayName)
    //    {
    //        var u = Builders<Data.Account>.Update.Set(x => x.DisplayName, request.DisplayName);
    //        updates.Add(u);
    //    }

    //    //if (request.Ha) {
    //    //    var u = Builders<Data.Account>.Update.Set(x => x.DisplayName, request.DisplayName);
    //    //    updates.Add(u);
    //    //}

    //    var update = Builders<Data.Account>.Update.Combine(updates);

    //    var account = await _db.Account.FindOneAndUpdateAsync(filter, update);

    //    return account.ToGrpc(host);
    //}

    //public override async Task<Grpc.Account> GetById(StringValue request, ServerCallContext context)
    //{
    //    var host = context.GetHost();
    //    var account = await _db.Account.FindByIdAsync(request.Value);

    //    return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc(host);
    //}

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
    public override Task<Grpc.Account> VerifyCredentials(Empty request, ServerCallContext context)
    {
        return base.VerifyCredentials(request, context);
    }

    [Authorize]
    [AllowAnonymous]
    public override Task<Statuses> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        return base.GetStatuses(request, context);
    }

    [Authorize]
    public override Task<Statuses> GetFavourites(DefaultPaginationParameters request, ServerCallContext context)
    {
        return base.GetFavourites(request, context);
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
    public override Task<Relationships> GetRelationships(GetRelationshipsRequest request, ServerCallContext context)
    {
        return base.GetRelationships(request, context);
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
