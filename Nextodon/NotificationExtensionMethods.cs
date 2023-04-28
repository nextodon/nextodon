namespace Nextodon;

public static class NotificationExtensionMethods
{
    public static async Task<Grpc.Notification> ToGrpc(this Nextodon.Data.PostgreSQL.Models.Notification i, Data.PostgreSQL.Models.Account? me, Data.PostgreSQL.MastodonContext db, ServerCallContext context)
    {
        var type = i.Type;
        var activityId = i.ActivityId;

        var v = new Grpc.Notification
        {
            Id = i.Id.ToString(),
            CreatedAt = i.CreatedAt.ToGrpc(),
        };

        var fromAccount = await db.Accounts.FindAsync(new object[] { i.FromAccountId }, cancellationToken: context.CancellationToken);

        if (fromAccount != null)
        {
            v.Account = await fromAccount!.ToGrpc(me, db, context);
        }

        if (type != null)
        {
            v.Type = type;
        }

        switch (type)
        {
            case "favourite":
                var favourite = await db.Favourites.FindAsync(new object[] { activityId }, cancellationToken: context.CancellationToken);
                if (favourite != null)
                {
                    var status = await db.Statuses.FindAsync(new object[] { favourite.StatusId }, cancellationToken: context.CancellationToken);
                    if (status != null)
                    {
                        v.Status = await status.ToGrpc(me, db, context);
                    }
                }

                break;

            case "reblog":
            case "status":
                break;
            case "mention":
                var mention = await db.Mentions.FindAsync(new object[] { activityId }, cancellationToken: context.CancellationToken);

                if (mention != null && mention.StatusId != null)
                {
                    var status = await db.Statuses.FindAsync(new object[] { mention.StatusId }, cancellationToken: context.CancellationToken);
                    if (status != null)
                    {
                        v.Status = await status.ToGrpc(me, db, context);
                    }
                }

                break;
            case "poll":
                var poll = await db.Polls.FindAsync(new object[] { activityId }, cancellationToken: context.CancellationToken);

                if (poll != null && poll.StatusId != null)
                {
                    var status = await db.Statuses.FindAsync(new object[] { poll.StatusId }, cancellationToken: context.CancellationToken);
                    if (status != null)
                    {
                        v.Status = await status.ToGrpc(me, db, context);
                    }
                }

                break;

            case "update":

                break;
        }

        return v;
    }
}
