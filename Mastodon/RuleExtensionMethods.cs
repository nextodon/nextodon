using Mastodon.Grpc;

namespace Mastodon;

public static class RuleExtensionMethods
{
    public static Grpc.Rule ToGrpc(this Mastodon.Models.Rule i)
    {
        return new Rule
        {
            Id = i.Id,
            Text = i.Text,
        };
    }
}
