namespace Nextodon.Services;

public sealed class NotificationApiService : Nextodon.Grpc.NotificationApi.NotificationApiBase
{

    private readonly ILogger<NotificationApiService> _logger;
    private readonly MastodonContext _db;

    public NotificationApiService(ILogger<NotificationApiService> logger, MastodonContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<Grpc.WebPushSubscription> Subscription(SubscriptionRequest request, ServerCallContext context)
    {
        var v = new Grpc.WebPushSubscription();

        v.Endpoint = "";

        return Task.FromResult(v);
    }
}
