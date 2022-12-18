using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;
using Mastodon.Models;

namespace Mastodon.Services;

public sealed class InstanceService : Mastodon.Grpc.Mastodon.MastodonBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<InstanceService> _logger;
    public InstanceService(ILogger<InstanceService> logger, MastodonClient mastodon)
    {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Grpc.InstanceV1> GetInstanceV1(Empty request, ServerCallContext context)
    {
        var instance = (await _mastodon.Instance.GetInstanceV1Async())!;

        instance.Uri = context.GetHttpContext().Request.Host.Value;

        return instance.ToGrpc();
    }

    public override async Task<Grpc.Instance> GetInstance(Empty request, ServerCallContext context)
    {
        var instance = (await _mastodon.Instance.GetInstanceAsync())!;

        instance.Domain = context.GetHttpContext().Request.Host.Value;

        return instance.ToGrpc();
    }

    public override async Task<Activities> GetActivities(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Instance.GetActivitiesAsync());
        return result.ToGrpc();
    }

    public override async Task<Rules> GetRules(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Instance.GetRulesAsync());
        return result.ToGrpc();
    }

    public override async Task<Grpc.Account> GetAccountById(StringValue request, ServerCallContext context)
    {
        var authorization = context.GetHttpContext().Request.Headers.Authorization.ToString();
        _mastodon.SetAuthorizationToken(authorization);

        var result = (await _mastodon.Accounts.GetByIdAsync(request.Value))!;
        return result.ToGrpc();
    }

    public override async Task<Statuses> GetAccountStatusesById(GetAccountStatusesByIdRequest request, ServerCallContext context)
    {
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

    public override async Task<Grpc.Status> GetStatusById(StringValue request, ServerCallContext context)
    {
        var result = (await _mastodon.Statuses.GetByIdAsync(request.Value))!;
        return result.ToGrpc();
    }

    public override async Task<Grpc.Context> GetStatusContextById(StringValue request, ServerCallContext context)
    {
        var result = (await _mastodon.Statuses.GetContextAsync(request.Value))!;
        return result.ToGrpc();
    }
}
