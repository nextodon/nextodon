namespace Nextodon.Data;

public static class ExtensionMethods
{
    public static async Task<T?> FindByIdAsync<T>(this IMongoCollection<T> collection, string id, bool excludeDeleted = false)
    {
        // FilterDefinition<T> filter = $"{{_id: \"{id}\" }}";
        FilterDefinition<T> filter = $"{{_id: ObjectId(\"{id}\") }}";

        if (excludeDeleted)
        {
            filter &= "{deleted: { $ne: true }}";
        }

        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.FirstOrDefaultAsync();

        return ret;
    }

    public static async Task<Account?> FindByIdAsync(this IMongoCollection<Account> collection, string id, bool excludeDeleted = false)
    {
        var filter = Builders<Account>.Filter.Eq(x => x.Id, id);

        if (excludeDeleted)
        {
            filter &= "{deleted: { $ne: true }}";
        }

        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.FirstOrDefaultAsync();

        return ret;
    }

    public static async Task<T?> FirstOrDefaultAsync<T>(this IMongoCollection<T> collection)
    {
        var filter = Builders<T>.Filter.Empty;
        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.FirstOrDefaultAsync();

        return ret;
    }

    public static async Task<List<T>> FindByIdsAsync<T>(this IMongoCollection<T> collection, IEnumerable<string> ids)
    {
        var objectIds = ids.Select(id => "ObjectId(\"{id}\")").ToList();
        var filter = Builders<T>.Filter.In("_id", objectIds);
        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.ToListAsync();

        return ret;
    }

    public static async Task<List<Account>> FindByIdsAsync(this IMongoCollection<Account> collection, IEnumerable<string> ids)
    {
        var filter = Builders<Account>.Filter.In("_id", ids);
        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.ToListAsync();

        return ret;
    }
}
