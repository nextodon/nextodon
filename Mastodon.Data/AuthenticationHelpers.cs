namespace Mastodon.Data;

public static class AuthenticationHelpers
{
    public static async Task<Account> FindOrCreateAsync(this IMongoCollection<Account> account, string publicKeyHex)
    {
        publicKeyHex = publicKeyHex.ToUpper();

        var now = DateTime.UtcNow;
        var filter = Builders<Data.Account>.Filter.Eq(x => x.PublicKey, publicKeyHex);
        var update = Builders<Data.Account>.Update
            .SetOnInsert(x => x.PublicKey, publicKeyHex)
            .SetOnInsert(x => x.CreatedAt, now)
            .SetOnInsert(x => x.Username, null)
            .SetOnInsert(x => x.DisplayName, null)
            .SetOnInsert(x => x.Discoverable, null)
            .SetOnInsert(x => x.Fields, new List<Account.Field>())
            .Set(x => x.LoggedInAt, now);


        var result = await account.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Data.Account, Data.Account> { IsUpsert = true });
       
        return result;
    }
}
