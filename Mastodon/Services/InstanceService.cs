using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;
using Mastodon.Models;

namespace Mastodon.Services;

public sealed class MastodonService : Mastodon.Grpc.Mastodon.MastodonBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<MastodonService> _logger;
    public MastodonService(ILogger<MastodonService> logger, MastodonClient mastodon)
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

        var v = new Activities();

        if (result != null)
        {
            foreach (var item in result)
            {
                v.Data.Add(item.ToGrpc());
            }
        }


        return v;
    }

    public override async Task<Rules> GetRules(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Instance.GetRulesAsync());

        var v = new Rules();

        if (result != null)
        {
            foreach (var item in result)
            {
                v.Data.Add(item.ToGrpc());
            }
        }


        return v;
    }

    public override async Task<Grpc.Statuses> GetPublicTimeline(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Timeline.GetPublicAsync());

        var statuses = new Grpc.Statuses();

        if (result != null)
        {
            foreach (var r in result)
            {
                statuses.Data.Add(r.ToGrpc());
            }
        }


        return statuses;
    }

    public override async Task<Statuses> GetPublicTimelineByTag(StringValue request, ServerCallContext context)
    {
        var result = (await _mastodon.Timeline.GetTagAsync(request.Value));

        var statuses = new Grpc.Statuses();

        if (result != null)
        {
            foreach (var r in result)
            {
                statuses.Data.Add(r.ToGrpc());
            }
        }


        return statuses;
    }

}