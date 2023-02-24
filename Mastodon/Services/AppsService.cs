namespace Mastodon.Services;

public sealed class AppsService : Mastodon.Grpc.Apps.AppsBase {

    private readonly ILogger<AppsService> _logger;
    private readonly Data.DataContext _db;

    public AppsService(ILogger<AppsService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }

    public override Task<Application> CreateApplication(CreateApplicationRequest request, ServerCallContext context) {

        var i = new Application {
            RedirectUri = "/sign_up",
            ClientId = "1",
            ClientSecret = "2"
        };

        return Task.FromResult(i);
    }

    public override Task<Application> VerifyCredentials(Empty request, ServerCallContext context) {
        return base.VerifyCredentials(request, context);
    }
}
