namespace Nextodon.Services;

public sealed class PollService : Nextodon.Grpc.PollApi.PollApiBase
{

    private readonly ILogger<PollService> _logger;
    public PollService(ILogger<PollService> logger)
    {
        _logger = logger;

    }

}
