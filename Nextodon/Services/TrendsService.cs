namespace Nextodon.Services;

public sealed class TrendsService : Nextodon.Grpc.Trends.TrendsBase
{

    private readonly ILogger<TrendsService> _logger;

    public TrendsService(ILogger<TrendsService> logger)
    {
        _logger = logger;
    }

    public override Task<Tags> GetTags(Empty request, ServerCallContext context)
    {
        return base.GetTags(request, context);
    }

    public override Task<Statuses> GetStatuses(Empty request, ServerCallContext context)
    {
        return base.GetStatuses(request, context);
    }
}
