using ForDem.Grpc;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace ForDem.Services;

[Authorize]
public sealed class WallService : Wall.WallBase
{
    private readonly ILogger<WallService> _logger;
    //private readonly Data.DataContext _db;
    public WallService(ILogger<WallService> logger/*, Data.DataContext db*/)
    {
        _logger = logger;
        //_db = db;
    }

    public override Task<CreatePostResponse> CreatePost(CreatePostRequest request, ServerCallContext context)
    {
        var user = context.GetHttpContext().User;

        return Task.FromResult(new CreatePostResponse { Id = user.Identity?.Name ?? string.Empty });
    }
}
