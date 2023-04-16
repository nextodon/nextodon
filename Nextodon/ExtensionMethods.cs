

using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Nextodon;

public static class ExtensionMethods
{
    public static string? GetAuthToken(this ServerCallContext context, [NotNullWhen(true)][MaybeNullWhen(false)] bool throwIfNotFound)
    {
        return context.GetHttpContext().GetAuthToken(throwIfNotFound);
    }

    public static string? GetAuthToken(this HttpContext context, [NotNullWhen(true)] bool throwIfNotFound)
    {
        var authorizationHeader = context.Request.Headers["Authorization"][0];
        if (string.IsNullOrWhiteSpace(authorizationHeader))
        {
            if (throwIfNotFound)
            {
                throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
            }

            return null;
        }

        var authorizationHeaderParts = authorizationHeader.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        if (authorizationHeaderParts.Length != 2 && throwIfNotFound)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
        }

        var token = authorizationHeaderParts[1];

        return token;
    }

    public static async Task<Data.PostgreSQL.Models.Account?> GetAccount(this ServerCallContext context, Data.PostgreSQL.MastodonContext db, [NotNullWhen(true)] bool throwIfNotFound)
    {
        var token = GetAuthToken(context, throwIfNotFound);

        var query = from x in db.OauthAccessTokens
                    where x.Token == token
                    select x.ResourceOwner!.Account;

        var account = await query.FirstOrDefaultAsync();

        if (throwIfNotFound && account == null)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
        }

        return account;
    }
}
