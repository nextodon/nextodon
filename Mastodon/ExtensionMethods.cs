

namespace Mastodon;

public static class ExtensionMethods {
    public static string? GetAccountId(this ServerCallContext context, bool throwIfNotFound) {
        return context.GetHttpContext().GetAccountId(throwIfNotFound);
    }

    public static string? GetAccountId(this HttpContext context, bool throwIfNotFound) {
        var identity = context.User;
        var accountId = identity?.Identity?.Name;

        if (throwIfNotFound) {
            accountId ??= "0xa98641d8031bc594ddb95f770f3101fa38c6efda";
        }

        if (throwIfNotFound && string.IsNullOrWhiteSpace(accountId)) {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
        }

        return accountId;
    }

    public static async Task<Data.Account?> GetAccount(this ServerCallContext context, Data.DataContext db, bool throwIfNotFound) {
        var accountId = GetAccountId(context, throwIfNotFound);

        var filter = Builders<Data.Account>.Filter.Eq(u => u.Id, accountId);
        var cursor = await db.Account.FindAsync(filter);

        var account = await cursor.FirstOrDefaultAsync();

        if (throwIfNotFound && account == null) {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Unauthenticated, ""));
        }

        return account;
    }
}
