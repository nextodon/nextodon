namespace Nextodon.Services;

public sealed class StreamingService : Nextodon.Grpc.Streaming.StreamingBase
{
    private readonly ILogger<StreamingService> _logger;
    private readonly Data.DataContext _db;
    private readonly EventSource<Grpc.Status> _es;

    public StreamingService(ILogger<StreamingService> logger, DataContext db, EventSource<Grpc.Status> es)
    {
        _logger = logger;
        _db = db;
        _es = es;
    }

    [Authorize]
    public override async Task GetStatusStream(Empty request, IServerStreamWriter<Grpc.Status> responseStream, ServerCallContext context)
    {
        var accountId = context.GetAuthToken(true);
        var channel = _es[accountId!];

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
