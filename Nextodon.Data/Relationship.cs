namespace Nextodon.Data;

public sealed class Relationship
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id = default!;

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public required string From;

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public required string To;

    [BsonRequired]
    public string? Note;
}
