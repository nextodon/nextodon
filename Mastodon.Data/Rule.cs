namespace Mastodon.Data;

public sealed class Rule
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id = default!;

    public required string Text;
}
