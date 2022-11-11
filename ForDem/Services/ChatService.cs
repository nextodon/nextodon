using ForDem.Grpc;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace ForDem.Services;

[AllowAnonymous]
[Authorize]
public sealed class ChatService : Chat.ChatBase
{
    private readonly ILogger<ChatService> _logger;
    private readonly Data.DataContext _db;
    public ChatService(ILogger<ChatService> logger, Data.DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    public override Task<SendResponse> Send(SendRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SendResponse
        {
            Data = "Hello " + request.Text,
        });
    }
}
