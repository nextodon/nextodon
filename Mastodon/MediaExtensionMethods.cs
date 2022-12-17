namespace Mastodon;

public static class MediaExtensionMethods
{
    public static Grpc.MediaAttachment ToGrpc(this Mastodon.Models.MediaAttachment i)
    {
        var v = new Grpc.MediaAttachment
        {
            Id = i.Id,
            Description = i.Description,
            PreviewUrl = i.PreviewUrl,
            Url = WebFingerHelper.FixUrl(i.Url),
            Type = i.Type,
            Meta = i.Meta.ToGrpc(),
        };

        if (i.Blurhash != null)
        {
            v.Blurhash = i.Blurhash;
        }

#pragma warning disable CS0612
        if (i.TextUrl != null)
        {
            v.TextUrl = i.TextUrl;
        }
#pragma warning restore CS0612

        if (i.RemoteUrl != null)
        {
            v.RemoteUrl = WebFingerHelper.FixUrl(i.RemoteUrl);
        }

        return v;
    }

    public static Grpc.MediaAttachment.Types.Meta ToGrpc(this Mastodon.Models.MediaAttachment.Types.Meta i)
    {
        var v = new Grpc.MediaAttachment.Types.Meta
        {
            Original = i.Original?.ToGrpc(),
            Small = i.Small?.ToGrpc(),
        };

        if (i.Aspect != null)
        {
            v.Aspect = i.Aspect.Value;
        }

        if (i.AudioBitrate != null)
        {
            v.AudioBitrate = i.AudioBitrate;
        }

        if (i.AudioChannels != null)
        {
            v.AudioChannels = i.AudioChannels;
        }
        if (i.AudioEncode != null)
        {
            v.AudioEncode = i.AudioEncode;
        }


        if (i.Duration != null) { v.Duration = i.Duration.Value; }
        if (i.Fps != null) { v.Fps = i.Fps.Value; }
        if (i.Height != null) { v.Height = i.Height.Value; }
        if (i.Length != null) { v.Length = i.Length; }
        if (i.Size != null) { v.Size = i.Size; }

        return v;
    }

    public static Grpc.MediaAttachment.Types.Meta.Types.Original ToGrpc(this Mastodon.Models.MediaAttachment.Types.Meta.Types.Original i)
    {
        var v = new Grpc.MediaAttachment.Types.Meta.Types.Original
        {
            Width = i.Width,
            Height = i.Height,
        };

        if (i.Duration != null) { v.Duration = i.Duration.Value; }
        if (i.Bitrate != null) { v.Bitrate = i.Bitrate.Value; }
        if (i.FrameRate != null) { v.FrameRate = i.FrameRate; }

        return v;
    }

    public static Grpc.MediaAttachment.Types.Meta.Types.Small ToGrpc(this Mastodon.Models.MediaAttachment.Types.Meta.Types.Small i)
    {
        var v = new Grpc.MediaAttachment.Types.Meta.Types.Small
        {
            Width = i.Width,
            Height = i.Height,
            Aspect = i.Aspect,
        };

        if (i.Size != null) { v.Size = i.Size; }

        return v;
    }
}
