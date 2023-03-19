namespace Mastodon.Data;

public sealed class Media
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id = default!;

    [BsonRequired]
    public required string AccountId;

    [BsonRequired]
    public required byte[] Content;
}
