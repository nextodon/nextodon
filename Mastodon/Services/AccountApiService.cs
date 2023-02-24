namespace Mastodon.Services;

public sealed class AccountApiService : Mastodon.Grpc.AccountApi.AccountApiBase {

    private readonly ILogger<AccountApiService> _logger;
    private readonly Data.DataContext _db;

    public AccountApiService(ILogger<AccountApiService> logger, DataContext db) {
        _logger = logger;

        _db = db;
    }

    public override Task<Token> Register(RegisterRequest request, ServerCallContext context) {
        return base.Register(request, context);
    }

    public override async Task<Grpc.Account> GetById(StringValue request, ServerCallContext context) {
        var account = await _db.Account.FindByIdAsync(request.Value);

        return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc();
    }

    /// <summary>
    /// Lookup account ID from Webfinger address.
    /// <br />
    /// Quickly lookup a username to see if it is available, skipping WebFinger resolution.
    /// </summary>
    public override Task<Grpc.Account> Lookup(LookupRequest request, ServerCallContext context) {
        return base.Lookup(request, context);
    }

    public override Task<Accounts> Search(AccountSearchRequest request, ServerCallContext context) {
        return base.Search(request, context);
    }

    [Authorize]
    public override async Task<Grpc.Account> VerifyCredentials(Empty request, ServerCallContext context) {
        var account = await context.GetAccount(_db, true);
        return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc();
    }

    public override async Task<Statuses> GetStatuses(GetStatusesRequest request, ServerCallContext context) {
        var limit = request.HasLimit ? request.Limit : 40;
        limit = Math.Min(limit, 80);

        var filters = new List<FilterDefinition<Data.Status>>
        {
            Builders<Data.Status>.Filter.Eq(x => x.AccountId, request.AccountId)
        };

        if (request.HasSinceId) {

        }

        var options = new FindOptions<Data.Status, Data.Status> { Limit = (int)limit };

        var filter = Builders<Data.Status>.Filter.And(filters);
        var cursor = await _db.Status.FindAsync(filter, options);
        var statuses = await cursor.ToListAsync();

        var account = await _db.Account.FindByIdAsync(request.AccountId);

        return statuses.ToGrpc(account!);
    }

    public override Task<FeaturedTags> GetFeaturedTags(StringValue request, ServerCallContext context) {
        return base.GetFeaturedTags(request, context);
    }

    public override Task<Accounts> GetFollowers(GetFollowersRequest request, ServerCallContext context) {
        return base.GetFollowers(request, context);
    }

    public override Task<Accounts> GetFollowing(GetFollowingRequest request, ServerCallContext context) {
        return base.GetFollowing(request, context);
    }

    public override Task<Grpc.Relationship> RemoveFromFollowers(StringValue request, ServerCallContext context) {
        return base.RemoveFromFollowers(request, context);
    }

    public override Task<Relationships> GetRelationships(GetRelationshipsRequest request, ServerCallContext context) {
        return base.GetRelationships(request, context);
    }

    public override Task<Lists> GetLists(StringValue request, ServerCallContext context) {
        return base.GetLists(request, context);
    }

    public override Task<Grpc.Relationship> Follow(StringValue request, ServerCallContext context) {
        return base.Follow(request, context);
    }

    public override Task<Grpc.Relationship> Unfollow(StringValue request, ServerCallContext context) {
        return base.Unfollow(request, context);
    }

    public override Task<Grpc.Relationship> Block(StringValue request, ServerCallContext context) {
        return base.Block(request, context);
    }

    public override Task<Grpc.Relationship> Unblock(StringValue request, ServerCallContext context) {
        return base.Unblock(request, context);
    }

    public override Task<Grpc.Relationship> Mute(StringValue request, ServerCallContext context) {
        return base.Mute(request, context);
    }

    public override Task<Grpc.Relationship> Unmute(StringValue request, ServerCallContext context) {
        return base.Unmute(request, context);
    }

    public override Task<Grpc.Relationship> Pin(StringValue request, ServerCallContext context) {
        return base.Pin(request, context);
    }

    public override Task<Grpc.Relationship> Unpin(StringValue request, ServerCallContext context) {
        return base.Unpin(request, context);
    }

    /// <summary>
    /// Sets a private note on a user.
    /// </summary>
    public override Task<Grpc.Relationship> Note(NoteRequest request, ServerCallContext context) {
        return base.Note(request, context);
    }
}
