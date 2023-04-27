

using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Nextodon;

public static class ExtensionMethods
{
    public static long? GetUserId(this HttpContext context, [NotNullWhen(true)] bool throwIfNotFound)
    {
        var name = context.User.Identity?.Name;

        if (!string.IsNullOrWhiteSpace(name))
        {
            if (long.TryParse(name, out var userId))
            {
                return userId;
            }
        }

        if (throwIfNotFound)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, string.Empty));
        }

        return null;
    }

    public static async Task<User?> GetUser(this HttpContext context, MastodonContext db, [NotNullWhen(true)] bool throwIfNotFound)
    {
        var userId = GetUserId(context, throwIfNotFound);

        if (userId != null)
        {
            var user = await db.Users.FindAsync(userId);

            if (user != null)
            {
                return user;
            }
        }

        if (throwIfNotFound)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, string.Empty));
        }

        return null;
    }

    public static Task<User?> GetUser(this ServerCallContext context, MastodonContext db, [NotNullWhen(true)] bool throwIfNotFound)
    {
        return GetUser(context.GetHttpContext(), db, throwIfNotFound);
    }

    public static async Task<Nextodon.Data.PostgreSQL.Models.Account?> GetAccount(this HttpContext context, MastodonContext db, [NotNullWhen(true)] bool throwIfNotFound)
    {
        var userId = GetUserId(context, throwIfNotFound);

        if (userId != null)
        {
            var user = await (from x in db.Users where x.Id == userId select x).Include(x => x.Account).FirstOrDefaultAsync();

            if (user?.Account != null)
            {
                return user.Account;
            }
        }

        if (throwIfNotFound)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, string.Empty));
        }

        return null;
    }

    public static Task<Data.PostgreSQL.Models.Account?> GetAccount(this ServerCallContext context, MastodonContext db, [NotNullWhen(true)] bool throwIfNotFound)
    {
        return GetAccount(context.GetHttpContext(), db, throwIfNotFound);
    }
}
