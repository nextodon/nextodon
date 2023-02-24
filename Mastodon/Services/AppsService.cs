namespace Mastodon.Services;

public sealed class AppsService : Mastodon.Grpc.Apps.AppsBase {

    private readonly ILogger<AppsService> _logger;
    private readonly Data.DataContext _db;

    public AppsService(ILogger<AppsService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }

    public override Task<Application> CreateApplication(CreateApplicationRequest request, ServerCallContext context) {
        return base.CreateApplication(request, context);
    }

    public override Task<Application> VerifyCredentials(Empty request, ServerCallContext context) {
        return base.VerifyCredentials(request, context);
    }
}
