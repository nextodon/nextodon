namespace Mastodon.Data;

[BsonIgnoreExtraElements]
public sealed class Status
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id = default!;

    [BsonRequired]
    public required string UserId;
    
    public required string? InReplyToId;

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ReblogedFromId = default!;

    [BsonRequired]
    public required DateTime CreatedAt;

    [BsonRequired]
    public required Visibility Visibility;

    [BsonRequired]
    public List<string>? MediaIds;

    [BsonRequired]
    public required string Text;

    [BsonRequired]
    public bool Sensitive;

    [BsonRequired]
    public Poll? Poll;

    public required string? Language;

    public required string? SpoilerText;

    [BsonRequired]
    public bool Deleted;


}
