using Mastodon.Grpc;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mastodon.Services;

[Authorize]
public sealed class AuthenticationService : Authentication.AuthenticationBase
{
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(ILogger<AuthenticationService> logger)
    {
        _logger = logger;
    }

    [AllowAnonymous]
    public override Task<JsonWebToken> SignIn(SignInRequest request, ServerCallContext context)
    {
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

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtkey = Encoding.UTF8.GetBytes("0102030405060708");

        var expires = DateTime.UtcNow.AddYears(1);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new Claim(JwtRegisteredClaimNames.UniqueName, publicKeyHex) }),
            Claims = new Dictionary<string, object> { [JwtRegisteredClaimNames.UniqueName] = publicKeyHex },
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtkey), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwttoken = tokenHandler.CreateToken(tokenDescriptor);

        var result = new JsonWebToken
        {
            Value = tokenHandler.WriteToken(jwttoken)
        };

        return Task.FromResult(result);
    }
}
