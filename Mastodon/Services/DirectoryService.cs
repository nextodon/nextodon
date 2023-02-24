namespace Mastodon.Services;

public sealed class DirectoryService : Mastodon.Grpc.Directory.DirectoryBase {
    private readonly MastodonClient _mastodon;
    private readonly ILogger<DirectoryService> _logger;
    public DirectoryService(ILogger<DirectoryService> logger, MastodonClient mastodon) {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Accounts> GetAccounts(GetDirectoryRequest request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Directory.GetDirectoryAsync(
            offset: request.HasOffset ? request.Offset : null,
            limit: request.HasLimit ? request.Limit : null,
            order: request.HasOrder ? request.Order : null,
            local: request.HasLocal ? request.Local : null);

        await result.WriteHeadersTo(context);

        return result.Data.ToGrpc();
    }
}
