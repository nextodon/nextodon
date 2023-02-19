using MongoDB.Driver;

namespace Mastodon.Services;

public sealed class AccountApiService : Mastodon.Grpc.AccountApi.AccountApiBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<AccountApiService> _logger;
    private readonly Data.DataContext _db;

    public AccountApiService(ILogger<AccountApiService> logger, MastodonClient mastodon, DataContext db)
    {
        _logger = logger;
        _mastodon = mastodon;
        _db = db;
    }

    public override async Task<Token> Register(RegisterRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.Register(
            request.Username, request.Email,
            request.Password, request.Agreement, request.Locale,
            request.HasReason ? request.Reason : null);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Grpc.Account> GetById(StringValue request, ServerCallContext context)
    {
        var account = await _db.Account.FindByIdAsync(request.Value);

        return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc();
    }

    /// <summary>
    /// Lookup account ID from Webfinger address.
    /// <br />
    /// Quickly lookup a username to see if it is available, skipping WebFinger resolution.
    /// </summary>
    public override async Task<Grpc.Account> Lookup(LookupRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.LookupAsync(request.Acct);
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Accounts> Search(AccountSearchRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.SearchAsync(request.Q,
            request.HasLimit ? request.Limit : null,
            request.HasOffset ? request.Offset : null,
            request.HasResolve ? request.Resolve : null,
            request.HasFollowing ? request.Following : null);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    [Authorize]
    public override async Task<Grpc.Account> VerifyCredentials(Empty request, ServerCallContext context)
    {
        var account = await context.GetUser(_db, true);
        return account == null ? throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty)) : account.ToGrpc();
    }

    public override async Task<Statuses> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        var limit = request.HasLimit ? request.Limit : 40;
        limit = Math.Min(limit, 80);

        var filters = new List<FilterDefinition<Data.Status>>
        {
            Builders<Data.Status>.Filter.Eq(x => x.UserId, request.AccountId)
        };

        if (request.HasSinceId)
        {

        }

        var options = new FindOptions<Data.Status, Data.Status> { Limit = (int)limit };

        var filter = Builders<Data.Status>.Filter.And(filters);
        var cursor = await _db.Status.FindAsync(filter, options);
        var statuses = await cursor.ToListAsync();

        var account = await _db.Account.FindByIdAsync(request.AccountId);

        return statuses.ToGrpc(account);
    }

    public override async Task<FeaturedTags> GetFeaturedTags(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetFeaturedTagsAsync(request.Value);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Accounts> GetFollowers(GetFollowersRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetFollowersAsync(request.AccountId,
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null);
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Accounts> GetFollowing(GetFollowingRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetFollowingAsync(request.AccountId,
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> RemoveFromFollowers(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.RemoveFromFollowersAsync(request.Value);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Relationships> GetRelationships(GetRelationshipsRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetRelationshipsAsync(request.Ids);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Lists> GetLists(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetListsAsync(request.Value);

        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Follow(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.FollowAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Unfollow(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.UnfollowAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Block(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.BlockAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Unblock(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.UnblockAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Mute(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.MuteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Unmute(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.UnmuteAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Pin(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.PinAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Unpin(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.UnpinAsync(request.Value);
        return result!.ToGrpc();
    }

    /// <summary>
    /// Sets a private note on a user.
    /// </summary>
    public override async Task<Grpc.Relationship> Note(NoteRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.NoteAsync(request.AccountId, request.HasComment ? request.Comment : null);
        return result!.ToGrpc();
    }
}
