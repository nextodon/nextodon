using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mastodon.Client;
using Mastodon.Grpc;
using Mastodon.Models;

namespace Mastodon.Services;

public sealed class TrendsService : Mastodon.Grpc.Trends.TrendsBase
{
    private readonly MastodonClient _mastodon;
    private readonly ILogger<TrendsService> _logger;
    public TrendsService(ILogger<TrendsService> logger, MastodonClient mastodon)
    {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Tags> GetTags(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Trends.GetTagsAsync());

        var v = new Tags();

        if (result != null)
        {
            foreach (var item in result)
            {
                v.Data.Add(item.ToGrpc());
            }
        }

        return v;
    }

    public override async Task<Statuses> GetStatuses(Empty request, ServerCallContext context)
    {
        var result = (await _mastodon.Trends.GetStatusesAsync());

        var v = new Statuses();

        if (result != null)
        {
            foreach (var item in result)
            {
                v.Data.Add(item.ToGrpc());
            }
        }

        return v;
    }
}