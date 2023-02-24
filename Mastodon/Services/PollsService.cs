namespace Mastodon.Services;

public sealed class PollService : Mastodon.Grpc.PollApi.PollApiBase {
    private readonly MastodonClient _mastodon;
    private readonly ILogger<PollService> _logger;
    public PollService(ILogger<PollService> logger, MastodonClient mastodon) {
        _logger = logger;
        _mastodon = mastodon;
    }

    public override async Task<Grpc.Poll> GetById(StringValue request, ServerCallContext context) {
        _mastodon.SetDefaults(context);
        var result = await _mastodon.Polls.GetByIdAsync(request.Value);
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);
        return result.Data!.ToGrpc();
    }

    public override async Task<Grpc.Poll> Vote(VoteRequest request, ServerCallContext context) {
        _mastodon.SetDefaults(context);
        var result = await _mastodon.Polls.VoteAsync(request.PollId, request.Choices.ToArray());
        result.RaiseExceptions();

        await result.WriteHeadersTo(context);
        return result.Data!.ToGrpc();
    }
}
