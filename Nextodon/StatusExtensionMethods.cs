namespace Nextodon;

public static class StatusExtensionMethods
{
    public static Grpc.Status ToGrpc(this Data.Status i, Data.Account account, string domain)
    {
        var v = new Grpc.Status
        {
            Id = i.Id,
            CreatedAt = Timestamp.FromDateTime(i.CreatedAt),
            Content = i.Text,
            Text = i.Text,
            Visibility = Grpc.Visibility.Public,
            Sensitive = i.Sensitive,
        };

        if (i.SpoilerText != null)
        {
            v.SpoilerText = i.SpoilerText;
        }

        if (i.Language != null)
        {
            v.Language = i.Language;
        }

        if (i.InReplyToId != null)
        {
            v.InReplyToId = i.InReplyToId;
        }

        if (account != null)
        {
            v.Account = account.ToGrpc(domain);
        }

        return v;
    }
}
