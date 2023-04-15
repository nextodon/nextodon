using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace Nextodon;

public static class PostgresExtensions
{
    public static async Task<Grpc.Status> ToGrpc(this Data.PostgreSQL.Models.Status i, Data.PostgreSQL.MastodonContext db, ServerCallContext context)
    {
        var v = new Grpc.Status
        {
            Id = i.Id.ToString(),
            Text = i.Text,
            Content = i.Text,
            SpoilerText = i.SpoilerText,
            Sensitive = i.Sensitive,
            CreatedAt = i.CreatedAt.ToGrpc(),
            EditedAt = i.EditedAt?.ToGrpc(),
            Language = i.Language,
            Visibility = Grpc.Visibility.Public,
        };

        if (i.InReplyToId != null)
        {
            v.InReplyToId = i.InReplyToId?.ToString();
        }

        if (i.InReplyToAccountId != null)
        {
            v.InReplyToAccountId = i.InReplyToAccountId?.ToString();
        }

        if (i.Uri != null)
        {
            v.Uri = i.Uri;
        }

        if (i.Url != null)
        {
            v.Url = i.Url;
        }

        var account = await db.Accounts.FindAsync(i.AccountId);
        if (account != null)
        {
            v.Account = await account.ToGrpc(db, context);
        }

        var pollQuery = from x in db.Polls
                        where x.StatusId == i.Id
                        select x;

        var poll = await pollQuery.FirstOrDefaultAsync();
        if (poll != null)
        {
            v.Poll = await poll.ToGrpc(db, context);
        }

        await Task.Yield();

        return v;
    }

    public static Task<Grpc.Account> ToGrpc(this Data.PostgreSQL.Models.Account i, Data.PostgreSQL.MastodonContext db, ServerCallContext context)
    {
        var v = new Grpc.Account
        {
            CreatedAt = i.CreatedAt.ToGrpc(),
            DisplayName = i.DisplayName,
            Id = i.Id.ToString(),
            Note = i.Note,
            Username = i.Username,
        };

        if (i.Url != null)
        {
            v.Url = i.Url;
        }

        return Task.FromResult(v);
    }

    public static Task<Grpc.Poll> ToGrpc(this Data.PostgreSQL.Models.Poll i, Data.PostgreSQL.MastodonContext db, ServerCallContext context)
    {
        var v = new Grpc.Poll
        {
            Id = i.Id.ToString(),
            ExpiresAt = i.ExpiresAt?.ToGrpc(),
            Multiple = i.Multiple,
        };

        foreach(var op in i.Options)
        {
            v.Options.Add(new Grpc.Poll.Types.Option { Title = op, VotesCount = 10 });
        }

        return Task.FromResult(v);
    }
}
