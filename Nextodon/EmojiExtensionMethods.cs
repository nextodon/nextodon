namespace Nextodon;

public static class EmojiExtensionMethods
{
    public static Grpc.CustomEmoji ToGrpc(this Nextodon.Data.PostgreSQL.Models.CustomEmoji i)
    {
        var v = new Grpc.CustomEmoji
        {
            Shortcode = i.Shortcode,
            VisibleInPicker = i.VisibleInPicker.GetValueOrDefault(),
        };

        //if (i.Category != null)
        //{
        //    v.Category = i.Category;
        //}

        //if (i.StaticUrl != null)
        //{
        //    v.StaticUrl = i.StaticUrl;
        //}

        return v;
    }
}
