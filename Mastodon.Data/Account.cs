namespace Mastodon.Data;

public sealed class Account
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id = default!;

    [BsonRequired]
    public required string PublicKey;

    [BsonRequired]
    public required DateTime CreatedAt;


    [BsonRequired]
    public required DateTime LoggedInAt;
}
