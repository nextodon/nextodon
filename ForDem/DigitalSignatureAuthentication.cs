using ForDem;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using SharpCompress.Compressors.Xz;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Authentication.DigitalSignature;

public sealed class DigitalSignatureHandler : AuthenticationHandler<DigitalSignatureOptions>
{
    private static readonly ReadOnlyMemory<byte> Magic = new byte[] { 77, 65, 71, 73, 67 };

    public DigitalSignatureHandler(IOptionsMonitor<DigitalSignatureOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock)
    {

    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var contentType = Context.Request.ContentType ?? string.Empty;
        if (!contentType.StartsWith("application/grpc", StringComparison.OrdinalIgnoreCase))
        {
            return AuthenticateResult.NoResult();
        }

        var publicKeyHex = Context.Request.Headers[Options.PublicKeyHeaderName].FirstOrDefault();
        var signatureHex = Context.Request.Headers[Options.SignatureHeaderName].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(publicKeyHex) || string.IsNullOrWhiteSpace(signatureHex))
        {
            return AuthenticateResult.NoResult();
        }

        Context.Request.EnableBuffering();

        var body = new MemoryStream();
        var stream = Context.Request.BodyReader.AsStream(true);
        var reader = new BinaryReader(stream);
        var compressed = reader.ReadBoolean();
        var length = reader.ReadInt32BE();
        var message = length > 0 ? reader.ReadBytes(length) : Magic.ToArray();


        var publicKeyBytes = ForDem.Cryptography.HashHelpers.StringToByteArray(publicKeyHex!);
        var signatureBytes = ForDem.Cryptography.HashHelpers.StringToByteArray(signatureHex!);

        var publicKey = new ForDem.Cryptography.PublicKey(publicKeyBytes);

        var valid = ForDem.Cryptography.Secp256K1.VerifySignature(publicKey, message, signatureBytes);

        if (!valid)
        {
            return AuthenticateResult.Fail("");
        }

        Context.Request.Body.Position = 0;

        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, publicKeyHex!) }, DigitalSignatureDefaults.AuthenticationScheme));
        var ticket = new AuthenticationTicket(principal, DigitalSignatureDefaults.AuthenticationScheme);

        return AuthenticateResult.Success(ticket);
    }
}

public sealed class DigitalSignatureOptions : AuthenticationSchemeOptions
{
    public string SignatureHeaderName { get; set; } = "x-digital-signature";
    public string PublicKeyHeaderName { get; set; } = "x-public-key";
}

public static class DigitalSignatureDefaults
{
    /// <summary>
    /// Default value for AuthenticationScheme property in the DigitalSignatureOptions.
    /// </summary>
    public const string AuthenticationScheme = "DigitalSignature";
}

public static class DigitalSignatureExtensions
{
    public static AuthenticationBuilder AddDigitalSignature(this AuthenticationBuilder builder, string authenticationScheme, string? displayName, Action<DigitalSignatureOptions> configureOptions)
    {
        return builder.AddScheme<DigitalSignatureOptions, DigitalSignatureHandler>(authenticationScheme, displayName, configureOptions);
    }

    public static AuthenticationBuilder AddDigitalSignature(this AuthenticationBuilder builder, Action<DigitalSignatureOptions> configureOptions)
    {
        return builder.AddDigitalSignature(DigitalSignatureDefaults.AuthenticationScheme, "DigitalSignature", configureOptions);
    }
}