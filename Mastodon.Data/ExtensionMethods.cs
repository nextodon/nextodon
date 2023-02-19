namespace Mastodon.Data;

public static class ExtensionMethods
{
    public static async Task<T?> FindByIdAsync<T>(this IMongoCollection<T> collection, string id)
    {
        // FilterDefinition<T> filter = $"{{_id: \"{id}\" }}";
        FilterDefinition<T> filter = $"{{_id: ObjectId(\"{id}\") }}";

        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.FirstOrDefaultAsync();

        return ret;
    }

    public static async Task<Account?> FindByIdAsync(this IMongoCollection<Account> collection, string id)
    {        var filter = Builders<Account>.Filter.Eq(x => x.Id, id);

        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.FirstOrDefaultAsync();

        return ret;
    }
}
