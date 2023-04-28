namespace Nextodon.Services;

[Authorize]
public sealed class NotificationApiService : Nextodon.Grpc.NotificationApi.NotificationApiBase
{

    private readonly ILogger<NotificationApiService> _logger;
    private readonly MastodonContext db;

    public NotificationApiService(ILogger<NotificationApiService> logger, MastodonContext db)
    {
        _logger = logger;
        this.db = db;
    }

    public override Task<Grpc.WebPushSubscription> Subscription(SubscriptionRequest request, ServerCallContext context)
    {
        var v = new Grpc.WebPushSubscription();

        v.Endpoint = "";

        return Task.FromResult(v);
    }

    public override async Task<Grpc.Notification> GetNotification(UInt64Value request, ServerCallContext context)
    {
        var me = await context.GetAccount(db, false);
        var cancellationToken = context.CancellationToken;

        var id = (long)request.Value;
        var notification = await db.Notifications.FindAsync(new object[] { id }, cancellationToken);

        if (notification == null)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, id.ToString()));
        }

        if (notification.AccountId != me!.Id)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.PermissionDenied, id.ToString()));
        }

        return await notification.ToGrpc(me, db, context);
    }

    public override async Task<Notifications> GetNotifications(GetNotificationsRequest request, ServerCallContext context)
    {
        var me = await context.GetAccount(db, true);
        var cancellationToken = context.CancellationToken;
        var types = request.Types_;
        var excludeTypes = request.ExcludeTypes;

        var query = from x in db.Notifications
                    where x.AccountId == me!.Id
                    where types.Contains(x.Type) && !excludeTypes.Contains(x.Type)
                    select x;

        var notifications = await query.ToListAsync(cancellationToken: cancellationToken);

        var v = new Grpc.Notifications();

        foreach (var n in notifications)
        {
            var notification = await n.ToGrpc(me, db, context);     
            v.Data.Add(notification);
        }

        return v;
    }
}
