using Microsoft.AspNetCore.Http.Extensions;

namespace Mastodon.Services;

public sealed class InstanceService : Mastodon.Grpc.InstanceApi.InstanceApiBase {

    private readonly ILogger<InstanceService> _logger;
    public InstanceService(ILogger<InstanceService> logger) {
        _logger = logger;

    }

    public override Task<InstanceV1> GetInstanceV1(Empty request, ServerCallContext context) {

        var i = new InstanceV1 {
            Uri = context.GetUrlPath(string.Empty),
            Title = context.GetUrlPath(string.Empty),
            Email = "admin@localhost",
            Description = "ForDem",
            ShortDescription = "ForDem",
            Version = "4.0.2",
            ApprovalRequired = false,
            Urls = new InstanceV1.Types.Urls { StreamingApi = "wss://mastodon.lol" },
            Thumbnail= "https://media.mastodon.lol/site_uploads/files/000/000/001/@1x/37615000e872f6a6.png",
            Stats = new InstanceV1.Types.Stats { },
        };

        i.Languages.Add("en");

        return Task.FromResult(i);
    }
}