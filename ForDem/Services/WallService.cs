using ForDem.Grpc;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

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

    public override async Task<Posts> GetPosts(Empty request, ServerCallContext context)
    {
        await Task.Yield();

        var ret = new Posts();

        ret.Data.Add(new Post { Id = "1", Text = "Test 1" });
        ret.Data.Add(new Post { Id = "2", Text = "Test 2" });

        return ret;
    }
}
