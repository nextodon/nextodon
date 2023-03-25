namespace Nextodon.Services;

public sealed class DirectoryService : Nextodon.Grpc.Directory.DirectoryBase
{
    private readonly ILogger<DirectoryService> _logger;

    public DirectoryService(ILogger<DirectoryService> logger)
    {
        _logger = logger;
    }

    public override Task<Accounts> GetAccounts(GetDirectoryRequest request, ServerCallContext context)
    {
        return base.GetAccounts(request, context);
    }
}
