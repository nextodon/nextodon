namespace Nextodon;

public static class ReportExtensionMethods
{
    public static async Task<Grpc.Report> ToGrpc(this Nextodon.Data.PostgreSQL.Models.Report i, Data.PostgreSQL.Models.Account? me, Data.PostgreSQL.MastodonContext db, ServerCallContext context)
    {
        var v = new Grpc.Report
        {
            Id = i.Id.ToString(),
            ActionTaken = i.ActionTakenAt != null,
            Category = i.Category.ToString(),
            Comment = i.Comment,
            CreatedAt = i.CreatedAt.ToGrpc(),
            Forwarded = i.Forwarded ?? false,
        };

        if (i.ActionTakenAt != null)
        {
            v.ActionTakenAt = i.ActionTakenAt.Value.ToGrpc();
        }

        var ruleIds = i.RuleIds;
        var statusIds = i.StatusIds;
        var targetAccountId = i.TargetAccountId;

        if (ruleIds != null)
        {
            foreach (var ruleId in ruleIds)
            {
                v.RuleIds.Add(ruleId.ToString());
            }
        }

        if (statusIds != null)
        {
            foreach (var statusId in statusIds)
            {
                v.StatusIds.Add(statusId.ToString());
            }
        }

        var targetAccount = await db.Accounts.FindAsync(new object[] { targetAccountId }, cancellationToken: context.CancellationToken);

        if (targetAccount != null)
        {
            v.TargetAccount = await targetAccount.ToGrpc(me, db, context);
        }

        return v;
    }
}
