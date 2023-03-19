namespace Mastodon;

public static class StatusExtensionMethods
{
    public static Grpc.Statuses ToGrpc(this IEnumerable<Mastodon.Data.Status>? i, Data.Account account)
    {
        var statuses = new Grpc.Statuses();
        if (i != null)
        {
            foreach (var r in i)
            {
                statuses.Data.Add(r.ToGrpc(account));
            }
        }

        return statuses;
    }

    //public static Grpc.Status.Types.Mention ToGrpc(this Mastodon.Data.Status.Mention i) {
    //    var v = new Grpc.Status.Types.Mention {
    //        Acct = WebFingerHelper.FixAcct(i.Acct),
    //        Id = i.Id,
    //        Url = WebFingerHelper.FixUrl(i.Url),
    //        Username = i.Username,
    //    };

    //    return v;
    //}

    //public static Grpc.Status.Types.Application ToGrpc(this Mastodon.Data.Status.ApplicationHash i) {
    //    var v = new Grpc.Status.Types.Application {
    //        Name = i.Name,
    //    };

    //    if (i.Website != null) {
    //        v.Website = i.Website;
    //    }

    //    return v;
    //}

    //public static Grpc.PreviewCard ToGrpc(this Mastodon.Data.PreviewCard i) {
    //    var v = new Grpc.PreviewCard {
    //        Url = WebFingerHelper.FixUrl(i.Url),
    //        AuthorName = i.AuthorName,
    //        AuthorUrl = WebFingerHelper.FixUrl(i.AuthorUrl),
    //        Description = i.Description,
    //        EmbedUrl = WebFingerHelper.FixUrl(i.EmbedUrl),
    //        Height = i.Height,
    //        Html = i.Html,
    //        ProviderName = i.ProviderName,
    //        ProviderUrl = WebFingerHelper.FixUrl(i.ProviderUrl),
    //        Title = i.Title,
    //        Type = i.Type,
    //        Width = i.Width,
    //    };

    //    if (i.Image != null) {
    //        v.Image = i.Image;
    //    }

    //    if (i.Blurhash != null) {
    //        v.Blurhash = i.Blurhash;
    //    }

    //    return v;
    //}

    public static Grpc.Status ToGrpc(this Data.Status i, Data.Account account)
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
            v.Account = account.ToGrpc();
        }

        return v;
    }


    //public static Grpc.Context ToGrpc(this Mastodon.Data.Context i) {
    //    var v = new Grpc.Context();

    //    v.Ancestors.AddRange(i.Ancestors.Select(x => x.ToGrpc()));
    //    v.Descendants.AddRange(i.Descendants.Select(x => x.ToGrpc()));

    //    return v;
    //}
}
