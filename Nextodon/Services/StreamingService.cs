namespace Nextodon.Services;

public sealed class StreamingService : Nextodon.Grpc.Streaming.StreamingBase
{

    private readonly ILogger<StreamingService> _logger;
    private readonly Data.DataContext _db;

    public StreamingService(ILogger<StreamingService> logger, DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override async Task User(Empty request, IServerStreamWriter<Empty> responseStream, ServerCallContext context)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await responseStream.WriteAsync(new Empty { });
            await Task.Delay(1000);
        }
    }
}
