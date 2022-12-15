using Mastodon.Grpc;

namespace Mastodon;

public static class EmojiExtensionMethods
{
    public static Grpc.CustomEmoji ToGrpc(this Mastodon.Models.CustomEmoji i)
    {
        var v = new CustomEmoji
        {
            Shortcode = i.Shortcode,
            Url = i.Url,
        };

        if (i.Category != null)
        {
            v.Category = i.Category;
        }

        if (i.StaticUrl != null)
        {
            v.StaticUrl = i.StaticUrl;
        }

        if (i.VisibleInPicker != null)
        {
            v.VisibleInPicker = i.VisibleInPicker.Value;
        }

        return v;
    }
}
