namespace Mastodon.Data;

[BsonIgnoreExtraElements]
public sealed class Status_Account {
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public required string Id = default!;

    [BsonRequired]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string StatusId;

    [BsonRequired]
    public required string AccountId;

    public required bool Deleted;

    [BsonRequired]
    public bool Favorite;

    [BsonRequired]
    public bool Mute;

    [BsonRequired]
    public bool Pin;

    [BsonRequired]
    public bool Bookmark;
}
