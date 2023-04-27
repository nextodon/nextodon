namespace Nextodon.Services;

public sealed class StreamingService : Nextodon.Grpc.Streaming.StreamingBase
{
    private readonly ILogger<StreamingService> _logger;
    private readonly MastodonContext db;
    private readonly EventSource<Grpc.Status, long> _es;

    public StreamingService(ILogger<StreamingService> logger, MastodonContext db, EventSource<Grpc.Status, long> es)
    {
        _logger = logger;
        this.db = db;
        _es = es;
    }

    [Authorize]
    public override async Task GetStatusStream(Empty request, IServerStreamWriter<Grpc.Status> responseStream, ServerCallContext context)
    {
        var account = await context.GetAccount(db, true);
        var channel = _es[account!.Id];

        while (!context.CancellationToken.IsCancellationRequested)
        {
            var status = await channel.Reader.ReadAsync(context.CancellationToken);
            await responseStream.WriteAsync(status);
        }
    }

    public override async Task User(Empty request, IServerStreamWriter<Empty> responseStream, ServerCallContext context)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await responseStream.WriteAsync(new Empty { });
            await Task.Delay(1000);
        }
    }

    public override Task Notification(Empty request, IServerStreamWriter<Empty> responseStream, ServerCallContext context)
    {
        return base.Notification(request, responseStream, context);
    }
}
