namespace Mastodon.Services;

public sealed class InstanceService : Mastodon.Grpc.InstanceApi.InstanceApiBase
{
    private readonly ILogger<InstanceService> _logger;
    private readonly Data.DataContext _db;

    public InstanceService(ILogger<InstanceService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<InstanceV1> GetInstanceV1(Empty request, ServerCallContext context)
    {
        var i = new InstanceV1();

        i.ContactAccount = new Account
        {
            Id = "1",
            Acct = "@mahdi",
            Username = "mahdi",
            Bot = false,
            CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow),
            Discoverable = true,
            DisplayName = "Mahdi",
            LastStatusAt = Timestamp.FromDateTime(DateTime.UtcNow),
            Role = new Role
            {
                Id = "1",
                Name = "admin"
            },
            Note = "Hello",
        };
        return base.GetInstanceV1(request, context);
    }
}
