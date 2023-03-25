namespace Nextodon.Services;

public sealed class NotificationApiService : Nextodon.Grpc.NotificationApi.NotificationApiBase
{

    private readonly ILogger<NotificationApiService> _logger;
    private readonly Data.DataContext _db;

    public NotificationApiService(ILogger<NotificationApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<WebPushSubscription> Subscription(SubscriptionRequest request, ServerCallContext context)
    {
        var v = new WebPushSubscription();

        v.Endpoint = "";

        return Task.FromResult(v);
    }
}
