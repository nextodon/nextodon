using Google.Protobuf.WellKnownTypes;

namespace Mastodon;

public static class StatusExtensionMethods
{
    public static Grpc.Statuses ToGrpc(this IEnumerable<Mastodon.Models.Status>? i)
    {
        var statuses = new Grpc.Statuses();
        if (i != null)
        {
            foreach (var r in i)
            {
                statuses.Data.Add(r.ToGrpc());
            }
        }

        return statuses;
    }

    public static Grpc.Status.Types.Mention ToGrpc(this Mastodon.Models.Status.Mention i)
    {
        var v = new Grpc.Status.Types.Mention
        {
            Acct = WebFingerHelper.FixAcct(i.Acct),
            Id = i.Id,
            Url = WebFingerHelper.FixUrl(i.Url),
            Username = i.Username,
        };

        return v;
    }

    public static Grpc.Status.Types.Application ToGrpc(this Mastodon.Models.Status.ApplicationHash i)
    {
        var v = new Grpc.Status.Types.Application
        {
            Name = i.Name,
        };

        if (i.Website != null)
        {
            v.Website = i.Website;
        }

        return v;
    }

    public static Grpc.PreviewCard ToGrpc(this Mastodon.Models.PreviewCard i)
    {
        var v = new Grpc.PreviewCard
        {
            Url = WebFingerHelper.FixUrl(i.Url),
            AuthorName = i.AuthorName,
            AuthorUrl = WebFingerHelper.FixUrl(i.AuthorUrl),
            Description = i.Description,
            EmbedUrl = WebFingerHelper.FixUrl(i.EmbedUrl),
            Height = i.Height,
            Html = i.Html,
            ProviderName = i.ProviderName,
            ProviderUrl = WebFingerHelper.FixUrl(i.ProviderUrl),
            Title = i.Title,
            Type = i.Type,
            Width = i.Width,
        };

        if (i.Image != null)
        {
            v.Image = i.Image;
        }

        if (i.Blurhash != null)
        {
            v.Blurhash = i.Blurhash;
        }

        return v;
    }

    public static Client.CreateStatus ToRest(this Grpc.CreateStatusRequest i)
    {
        return new Client.CreateStatus
        {
            Status = i.Status,
            Visibility = i.Visibility,
            MediaIds = i.MediaIds.ToList(),
            Sensitive = i.Sensitive,
            Poll = i.Poll?.ToRest(),
        };
    }

    public static Client.CreateStatus.Types.Poll ToRest(this Grpc.CreateStatusRequest.Types.Poll i)
    {
        return new Client.CreateStatus.Types.Poll
        {
            ExpiresIn = i.ExpiresIn,
            HideTotals = i.HideTotals,
            Multiple = i.TypeCase == Grpc.CreateStatusRequest.Types.Poll.TypeOneofCase.Multiple ? i.Multiple : i.Kind != Grpc.PollKind.Single,
            Options = i.Options.ToList(),
        };
    }

    public static Grpc.Status ToGrpc(this Mastodon.Models.Status i)
    {
        var v = new Grpc.Status
        {
            Account = i.Account.ToGrpc(),
            Id = i.Id,
            Bookmarked = i.Bookmarked,
            CreatedAt = Timestamp.FromDateTime(i.CreatedAt),
            Uri = WebFingerHelper.FixUrl(i.Uri),
            Visibility = i.Visibility,
            SpoilerText = i.SpoilerText,
            Favourited = i.Favourited,
            FavouritesCount = i.FavouritesCount,
            Muted = i.Muted,
            Pinned = i.Pinned,
            Reblog = i.Reblog?.ToGrpc(),
            Reblogged = i.Reblogged,
            Sensitive = i.Sensitive,
            ReblogsCount = i.ReblogsCount,
            RepliesCount = i.RepliesCount,
            EditedAt = i.EditedAt?.ToGrpc(),
            Application = i.Application?.ToGrpc(),
            Card = i.Card?.ToGrpc(),
        };

        if (i.Content != null)
        {
            v.Content = i.Content;
        }

        if (i.Url != null)
        {
            v.Url = WebFingerHelper.FixUrl(i.Url);
        }

        if (i.InReplyToAccountId != null)
        {
            v.InReplyToAccountId = i.InReplyToAccountId;
        }

        if (i.InReplyToId != null)
        {
            v.InReplyToId = i.InReplyToId;
        }

        if (i.Language != null)
        {
            v.Language = i.Language;
        }

        if (i.Text != null)
        {
            v.Text = i.Text;
        }

        v.Tags.AddRange(i.Tags.Select(t => t.ToGrpc()));
        v.MediaAttachments.AddRange(i.MediaAttachments.Select(t => t.ToGrpc()));
        v.Emojis.AddRange(i.Emojis.Select(x => x.ToGrpc()));
        v.Mentions.AddRange(i.Mentions.Select(x => x.ToGrpc()));

        return v;
    }

    public static Grpc.Context ToGrpc(this Mastodon.Models.Context i)
    {
        var v = new Grpc.Context();

        v.Ancestors.AddRange(i.Ancestors.Select(x => x.ToGrpc()));
        v.Descendants.AddRange(i.Descendants.Select(x => x.ToGrpc()));

        return v;
    }
}
