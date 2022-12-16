namespace Mastodon;

public static class MediaExtensionMethods
{
    public static Grpc.MediaAttachment ToGrpc(this Mastodon.Models.MediaAttachment i)
    {
        return new Grpc.MediaAttachment
        {
            Id = i.Id,
        };
    }
}
