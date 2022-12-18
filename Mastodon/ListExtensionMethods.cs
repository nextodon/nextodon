using Mastodon.Grpc;

namespace Mastodon;

public static class ListExtensionMethods
{
    public static Grpc.List ToGrpc(this Mastodon.Models.List i)
    {
        return new List
        {
            Id = i.Id,
            RepliesPolicy = i.RepliesPolicy,
            Title = i.Title,
        };
    }

    public static Grpc.Lists ToGrpc(this IEnumerable<Mastodon.Models.List>? i)
    {
        var v = new Lists();

        if (i != null)
        {
            v.Data.AddRange(i.Select(x => x.ToGrpc()));
        }

        return v;
    }
}
