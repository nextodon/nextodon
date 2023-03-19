using System;

namespace Mastodon.Services;

public sealed class MediaApiService : Mastodon.Grpc.MediaApi.MediaApiBase
{
    private readonly ILogger<MediaApiService> _logger;
    private readonly Data.DataContext _db;

    public MediaApiService(ILogger<MediaApiService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override async Task<MediaAttachment> GetMedia(StringValue request, ServerCallContext context)
    {
        var media = await _db.Media.FindByIdAsync(request.Value);

        if (media == null)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, ""));
        }

        var v = media!.ToGrpc();

        var url = context.GetUrlPath($"/api/v1/media/{media.Id}");
        v.Url = $"{url}/original";
        v.PreviewUrl = $"{url}/preview";
        v.Type = "image";
        v.Blurhash = "LGF5?xYk^6#M@-5c,1J5@[or[Q6.";

        return v;
    }
}
