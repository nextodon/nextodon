

namespace Mastodon;

public static class ExtensionMethods
{
    public static string? GetUserId(this ServerCallContext context, bool throwIfNotFound)
    {
        var identity = context.GetHttpContext().User;
        var userId = identity?.Identity?.Name;

        if (throwIfNotFound && string.IsNullOrWhiteSpace(userId))
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
        }

        return userId;
    }

    public static async Task<Data.Account?> GetUser(this ServerCallContext context, Data.DataContext db, bool throwIfNotFound)
    {
        var userId = GetUserId(context, throwIfNotFound);

        var filter = Builders<Data.Account>.Filter.Eq(u => u.Id, userId);
        var cursor = await db.Account.FindAsync(filter);

        var user = await cursor.FirstOrDefaultAsync();

        if (throwIfNotFound && user == null)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
        }

        return user;
    }
}
