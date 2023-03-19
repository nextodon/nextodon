namespace Mastodon.Services;

public sealed class PollService : Mastodon.Grpc.PollApi.PollApiBase
{

    private readonly ILogger<PollService> _logger;
    public PollService(ILogger<PollService> logger)
    {
        _logger = logger;

    }

}
