namespace Nextodon;

public static class PostgresExtensions
{
    public static async Task< Grpc.Status> ToGrpc(this Data.PostgreSQL.Models.Status i, Data.PostgreSQL.MastodonContext db, ServerCallContext context)
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

        await Task.Yield();

        return v;
    }
}
