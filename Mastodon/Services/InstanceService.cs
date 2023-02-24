using Microsoft.AspNetCore.Http.Extensions;

namespace Mastodon.Services;

public sealed class InstanceService : Mastodon.Grpc.InstanceApi.InstanceApiBase {
    
    private readonly ILogger<InstanceService> _logger;
    public InstanceService(ILogger<InstanceService> logger) {
        _logger = logger;
        
    }
}