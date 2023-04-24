namespace Nextodon.Services;

public sealed class MediaApiService : Nextodon.Grpc.MediaApi.MediaApiBase
{
    private readonly ILogger<MediaApiService> _logger;
    private readonly MastodonContext db;

    public MediaApiService(ILogger<MediaApiService> logger, MastodonContext db)
    {
        _logger = logger;
        this.db = db;
    }

    //public override async Task<MediaAttachment> GetMedia(StringValue request, ServerCallContext context)
    //{
    //    var media = await _db.Media.FindByIdAsync(request.Value);

    //    if (media == null)
    //    {
    //        throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, $"Media not found: {request.Value}"));
    //    }

    //    var v = media!.ToGrpc();

    //    var url = context.GetUrlPath($"/api/v1/media/{media.Id}");
    //    v.Url = $"{url}/original";
    //    v.PreviewUrl = $"{url}/preview";
    //    v.Type = "image";
    //    v.Blurhash = "LGF5?xYk^6#M@-5c,1J5@[or[Q6.";

    //    return v;
    //}
}
