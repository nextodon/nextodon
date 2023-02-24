namespace Mastodon.Services;

public sealed class MediaApiService : Mastodon.Grpc.MediaApi.MediaApiBase {
    private readonly MastodonClient _mastodon;
    private readonly ILogger<MediaApiService> _logger;

    public MediaApiService(ILogger<MediaApiService> logger, MastodonClient mastodon) {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<MediaAttachment> GetMedia(StringValue request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Media.GetMediaAsync(request.Value);
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }
}
