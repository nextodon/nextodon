using Mastodon.Grpc;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MongoDB.Driver;
using Mastodon.Cryptography;

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
        var publicKey = new Mastodon.Cryptography.PublicKey(publicKeyBytes);

        var signatureBytes = request.DigitalSignature.ToArray();
        var messageBytes = Cryptography.HashHelpers.SHA256(publicKeyBytes);

        var valid = Cryptography.Secp256K1.VerifySignature(publicKey, messageBytes, signatureBytes);

        if (!valid)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.InvalidArgument, string.Empty));
        }

        var id = publicKey.CreateAddress();

        var account = await _db.Account.FindOrCreateAsync(id);
        var accountId = account.Id;
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = jwtOptions.SecretKey;
        var jwtkey = Encoding.UTF8.GetBytes(key);

        var expires = DateTime.UtcNow.AddYears(1);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new Claim(JwtRegisteredClaimNames.UniqueName, accountId) }),
            Claims = new Dictionary<string, object> { [JwtRegisteredClaimNames.UniqueName] = accountId },
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
