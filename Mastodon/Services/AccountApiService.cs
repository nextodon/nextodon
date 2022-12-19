using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;
using Mastodon.Models;

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

    public override async Task<Grpc.Account> GetAccount(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = (await _mastodon.Accounts.GetByIdAsync(request.Value))!;
        return result.ToGrpc();
    }

    public override async Task<Statuses> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

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

        return result.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Follow(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Accounts.FollowAsync(request.Value);
        return result!.ToGrpc();
    }

    public override async Task<Grpc.Relationship> Unfollow(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = await _mastodon.Accounts.UnfollowAsync(request.Value);
        return result!.ToGrpc();
    }
}
