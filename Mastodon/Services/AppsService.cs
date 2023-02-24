namespace Mastodon.Services;

public sealed class AppsService : Mastodon.Grpc.Apps.AppsBase {
    private readonly MastodonClient _mastodon;
    private readonly ILogger<AppsService> _logger;
    public AppsService(ILogger<AppsService> logger, MastodonClient mastodon) {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Application> CreateApplication(CreateApplicationRequest request, ServerCallContext context) {
        var result = await _mastodon.Apps.CreateApplication(
            clientName: request.ClientName,
            redirectUris: request.RedirectUris,
            scopes: request.HasScopes ? request.Scopes : null,
            website: request.HasWebsite ? request.Website : null
            );

        return result!.ToGrpc();
    }

    public override async Task<Application> VerifyCredentials(Empty request, ServerCallContext context) {
        _mastodon.SetDefaults(context);

        var result = await _mastodon.Apps.VerifyCredentials();
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);

        return result.Data!.ToGrpc();
    }
}
