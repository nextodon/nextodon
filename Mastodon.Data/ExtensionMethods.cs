namespace Mastodon.Data;

public static class ExtensionMethods
{
    public static async Task<T?> FindByIdAsync<T>(this IMongoCollection<T> collection, string id)
    {
        FilterDefinition<T> filter = $"{{_id: ObjectId(\"{id}\") }}";
        var cursor = await collection.FindAsync(filter);

        var ret = await cursor.FirstOrDefaultAsync();

        return ret;
    }
}
