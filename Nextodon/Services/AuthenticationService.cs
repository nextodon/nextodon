using Nextodon.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Nextodon.Services;

[Authorize]
public sealed class AuthenticationService : Authentication.AuthenticationBase
{
    private readonly IConfiguration _config;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly Data.PostgreSQL.MastodonContext db;

    public AuthenticationService(ILogger<AuthenticationService> logger, IConfiguration config, Data.PostgreSQL.MastodonContext db)
    {
        this.db = db;
        _logger = logger;
        _config = config;
    }

    [AllowAnonymous]
    public override async Task<JsonWebToken> SignIn(SignInRequest request, ServerCallContext context)
    {
        var remoteIpAddress = context.GetHttpContext().Connection.RemoteIpAddress;

        var jwtOptions = _config.GetSection("JwtSettings").Get<JwtOptions>()!;

        var publicKeyBytes = request.PublicKey.ToArray();
        var publicKey = new Nextodon.Cryptography.PublicKey(publicKeyBytes);

        var signatureBytes = request.Signature.ToArray();
        var messageBytes = Cryptography.HashHelpers.SHA256(publicKeyBytes);

        var valid = Cryptography.Secp256K1.VerifySignature(publicKey, messageBytes, signatureBytes);

        if (!valid)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.InvalidArgument, string.Empty));
        }

        var pk = publicKey.Compress().ToString().ToLower();
        var username = publicKey.ToEthereumAddress();
        if (!username.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
        {
            username = $"0x{username}";
        }

        username = username.ToLower();

        var account = (from x in db.Accounts.Include(y => y.Users).ThenInclude(y => y.OauthAccessTokens)
                       where x.Username == username
                       select x).FirstOrDefault();

        var now = DateTime.UtcNow;

        if (account == null)
        {
            account = new Data.PostgreSQL.Models.Account
            {
                Username = username,
                DisplayName = username,
                CreatedAt = now,
                UpdatedAt = now,
            };

            var user = new Data.PostgreSQL.Models.User
            {
                Approved = true,
                Account = account,
                ConfirmedAt = now,
                UpdatedAt = now,
                ConfirmationSentAt = now,
                CreatedAt = now,
                LastSignInAt = now,

                Locale = "en",
                Email = $"{username}@nextodon.dev",
                SignUpIp = remoteIpAddress,
            };

            account.Users.Add(user);
            await db.Accounts.AddAsync(account);
            await db.SaveChangesAsync();
        }

        account.UpdatedAt = now;

        db.Accounts.Update(account);
        await db.SaveChangesAsync();

        var user = account.Users.First();

        var accountId = account.Id;
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = jwtOptions.SecretKey;
        var jwtkey = Encoding.UTF8.GetBytes(key);

        var expires = DateTime.UtcNow.AddYears(1);
        var jti = Guid.NewGuid().ToString();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()) }),
            Claims = new Dictionary<string, object>
            {
                [JwtRegisteredClaimNames.UniqueName] = accountId,
                [JwtRegisteredClaimNames.Jti] = jti,
            },
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtkey), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwttoken = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(jwttoken);


        var token = new Data.PostgreSQL.Models.OauthAccessToken
        {
            CreatedAt = now,
            LastUsedAt = now,
            Token = jwt,
            ResourceOwner = user,
        };

        db.OauthAccessTokens.Add(token);
        await db.SaveChangesAsync();


        var v = new JsonWebToken
        {
            Value = jwt,
        };

        return v;
    }
}
