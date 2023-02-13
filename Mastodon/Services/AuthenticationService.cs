using Mastodon.Grpc;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MongoDB.Driver;

namespace Mastodon.Services;

[Authorize]
public sealed class AuthenticationService : Authentication.AuthenticationBase
{
    private readonly IConfiguration _config;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly Data.DataContext _db;

    public AuthenticationService(ILogger<AuthenticationService> logger, IConfiguration config, DataContext db)
    {
        _logger = logger;
        _config = config;
        _db = db;
    }

    [AllowAnonymous]
    public override async Task<JsonWebToken> SignIn(SignInRequest request, ServerCallContext context)
    {
        var jwtOptions = _config.GetSection("JwtSettings").Get<JwtOptions>()!;

        var publicKeyBytes = request.PublicKey.ToArray();
        var signatureBytes = request.DigitalSignature.ToArray();
        var messageBytes = Cryptography.HashHelpers.SHA256(publicKeyBytes);

        var publicKeyHex = Cryptography.HashHelpers.ByteArrayToHexString(publicKeyBytes);
        var publicKey = new Mastodon.Cryptography.PublicKey(publicKeyBytes);

        var valid = Mastodon.Cryptography.Secp256K1.VerifySignature(publicKey, messageBytes, signatureBytes);

        if (!valid)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.InvalidArgument, string.Empty));
        }

        var now = DateTime.UtcNow;
        var filter = Builders<Data.Account>.Filter.Eq(x => x.PublicKey, publicKeyHex);
        var update = Builders<Data.Account>.Update
            .SetOnInsert(x => x.PublicKey, publicKeyHex)
            .SetOnInsert(x => x.CreatedAt, now)
            .Set(x => x.LoggedInAt, now);


        var result = await _db.User.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Data.Account, Data.Account> { IsUpsert = true });

        var userId = result.Id;
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = jwtOptions.SecretKey;
        var jwtkey = Encoding.UTF8.GetBytes(key);

        var expires = DateTime.UtcNow.AddYears(1);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new Claim(JwtRegisteredClaimNames.UniqueName, userId) }),
            Claims = new Dictionary<string, object> { [JwtRegisteredClaimNames.UniqueName] = userId },
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtkey), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwttoken = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = new JsonWebToken
        {
            Value = tokenHandler.WriteToken(jwttoken)
        };

        return jwt;
    }
}
