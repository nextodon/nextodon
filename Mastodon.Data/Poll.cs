namespace Mastodon.Data;

[BsonIgnoreExtraElements]
public sealed class Poll {
    [BsonRequired]
    public required PollKind Kind;

    [BsonRequired]
    public required Dictionary<string, Vote> Votes;

    [BsonRequired]
    public required List<string> Options;

    [BsonRequired]
    public required uint ExpiresIn;

    [BsonRequired]
    public required bool HideTotals;
}

[BsonIgnoreExtraElements]
public sealed class Vote {
    public required string UserId;
    public required List<VoteChoice> Choices;
}

[BsonIgnoreExtraElements]
public sealed class VoteChoice {
    public required uint Choice;
    public required uint Weight;
}
