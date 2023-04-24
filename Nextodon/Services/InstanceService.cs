namespace Nextodon.Services;

public sealed class InstanceService : Nextodon.Grpc.InstanceApi.InstanceApiBase
{
    private readonly ILogger<InstanceService> _logger;
    private readonly MastodonContext db;

    public InstanceService(ILogger<InstanceService> logger, MastodonContext db)
    {
        _logger = logger;
        this.db = db;
    }

    public override Task<Grpc.Instance> GetInstance(Empty request, ServerCallContext context)
    {
        return base.GetInstance(request, context);
    }

    public override Task<InstanceV1> GetInstanceV1(Empty request, ServerCallContext context)
    {
        return base.GetInstanceV1(request, context);
    }

    public override Task<Lists> GetLists(Empty request, ServerCallContext context)
    {
        var lists = new Lists();

        return Task.FromResult(lists);
    }

    public override Task<Announcements> GetAnnouncements(Empty request, ServerCallContext context)
    {
        var lists = new Announcements();

        return Task.FromResult(lists);
    }
}