namespace Mastodon.Data;

public sealed class Marker
{
    [BsonElement("_id")]
    [BsonRequired]
    public required string AccountId;

    [BsonRequired]
    public MarkerItem? Home;

    [BsonRequired]
    public MarkerItem? Notifications;


    public sealed class MarkerItem
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public required string LastReadId;

        [BsonRequired]
        public required uint Version;

        [BsonRequired]
        public required DateTime UpdatedAt;
    }
}

