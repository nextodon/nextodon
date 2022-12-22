using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;

namespace Mastodon.Services;

public sealed class AccountApiService : Mastodon.Grpc.AccountApi.AccountApiBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<AccountApiService> _logger;

    public AccountApiService(ILogger<AccountApiService> logger, MastodonClient mastodon)
    {
        _logger = logger;
        _mastodon = mastodon;
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

    public override async Task<Grpc.Account> GetAccount(StringValue request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetByIdAsync(request.Value);
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Account> VerifyCredentials(Empty request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.VerifyCredentials();

        if (!result.IsSuccessStatusCode)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Internal, result.StatusCode.ToString()));
        }

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }

    public override async Task<Statuses> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Accounts.GetStatusesByIdAsync(request.AccountId,
            sinceId: request.HasSinceId ? request.SinceId : null,
            maxId: request.HasMaxId ? request.MaxId : null,
            minId: request.HasMinId ? request.MinId : null,
            limit: request.HasLimit ? request.Limit : null,
            onlyMedia: request.HasOnlyMedia ? request.OnlyMedia : null,
           excludeReplies: request.HasExcludeReplies ? request.ExcludeReplies : null,
           excludeReblogs: request.HasExcludeReblogs ? request.ExcludeReblogs : null,
           pinned: request.HasPinned ? request.Pinned : null,
           tagged: request.HasTagged ? request.Tagged : null);

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

    public override async Task<Relationship> RemoveFromFollowers(StringValue request, ServerCallContext context)
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
