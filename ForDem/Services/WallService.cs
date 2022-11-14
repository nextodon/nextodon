using ForDem.Grpc;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace ForDem.Services;

[AllowAnonymous]
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
        var message = request.ToByteArray();

        var publicKeyHex = context.RequestHeaders.Get("x-public-key")?.Value;
        var signatureHex = context.RequestHeaders.Get("x-digital-signature")?.Value;

        if (publicKeyHex == null || signatureHex == null)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, string.Empty));
        }


        var publicKeyBytes = Cryptography.HashHelpers.StringToByteArray(publicKeyHex);
        var signatureBytes = Cryptography.HashHelpers.StringToByteArray(signatureHex);

        var publicKey = new Cryptography.PublicKey(publicKeyBytes);

        var valid = Cryptography.Secp256K1.VerifySignature(publicKey, message, signatureBytes);

        if (!valid)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, string.Empty));
        }

        return Task.FromResult(new CreatePostResponse { Id = Guid.NewGuid().ToString() });
    }
}
