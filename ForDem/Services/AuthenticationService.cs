using ForDem.Grpc;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication.DigitalSignature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ForDem.Services;

[Authorize(AuthenticationSchemes = DigitalSignatureDefaults.AuthenticationScheme)]
public sealed class AuthenticationService : Authentication.AuthenticationBase
{
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(ILogger<AuthenticationService> logger)
    {
        _logger = logger;
    }

    public override Task<JsonWebToken> GetJwt(Empty request, ServerCallContext context)
    {
        var user = context.GetHttpContext().User.Identity;

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtkey = Encoding.UTF8.GetBytes("0102030405060708");

        var expires = DateTime.UtcNow.AddYears(1);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new Claim(JwtRegisteredClaimNames.UniqueName, user!.Name) }),
            Claims = new Dictionary<string, object> { [JwtRegisteredClaimNames.UniqueName] = user.Name },
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
