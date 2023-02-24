namespace Mastodon.Services;

[Authorize]
public sealed class AccountApiService : Mastodon.Grpc.AccountApi.AccountApiBase {
    private readonly ILogger<AccountApiService> _logger;
    private readonly Data.DataContext _db;

    public AccountApiService(ILogger<AccountApiService> logger, Data.DataContext db) {
        _logger = logger;
        _db = db;
    }
}
