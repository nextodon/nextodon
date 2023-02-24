namespace Mastodon;

public static class TagExtensionMethods {
    public static Grpc.Tags ToGrpc(this IEnumerable<Mastodon.Models.Tag>? i) {
        var tags = new Grpc.Tags();

        if (i != null) {
            foreach (var r in i) {
                tags.Data.Add(r.ToGrpc());
            }
        }

        return tags;
    }

    public static Grpc.Tag ToGrpc(this Mastodon.Models.Tag i) {
        var v = new Grpc.Tag {
            Name = i.Name,
            Url = WebFingerHelper.FixUrl(i.Url),
            Following = i.Following ?? false,
        };

        if (i.History != null) {
            v.History.AddRange(i.History.Select(ToGrpc));
        }

        return v;
    }

    public static Grpc.Tag.Types.TagHistory ToGrpc(this Mastodon.Models.Tag.TagHistory i) {
        var v = new Grpc.Tag.Types.TagHistory {
            Day = i.Day,
            Uses = i.Uses,
            Accounts = i.Accounts,
        };

        return v;
    }
}
