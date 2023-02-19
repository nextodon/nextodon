namespace Mastodon.Data;

public sealed class Account
{
    [BsonElement("_id")]
    [BsonRequired]
    public required string Id;

    [BsonRequired]
    public string? Username;

    [BsonRequired]
    public string? DisplayName;

    [BsonRequired]
    public bool? Discoverable;

    [BsonRequired]
    public required DateTime CreatedAt;


    [BsonRequired]
    public required DateTime LoggedInAt;
    
    [BsonRequired]
    public required List<Field> Fields;

    public sealed class Field
    {
        [BsonRequired]
        public required string Name;

        [BsonRequired]
        public required string Value;

        [BsonRequired]
        public DateTime? VerifiedAt;
    }
}
