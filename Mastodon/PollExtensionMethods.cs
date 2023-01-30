using Mastodon.Grpc;

namespace Mastodon;

public static class PollExtensionMethods
{
    public static Grpc.Poll ToGrpc(this Mastodon.Models.Poll i)
    {
        var v = new Grpc.Poll
        {
            Id = i.Id,
            Expired = i.Expired,
            Multiple = i.Multiple,
            VotesCount = i.VotesCount,
        };

        if (i.ExpiresAt != null)
        {
            v.ExpiresAt = i.ExpiresAt.Value.ToGrpc();
        }

        if (i.Voted != null)
        {
            v.Voted = i.Voted.Value;
        }

        if (i.VotersCount != null)
        {
            v.VotersCount = i.VotersCount.Value;
        }

        if (i.OwnVotes != null)
        {
            v.OwnVotes.AddRange(i.OwnVotes);
        }

        v.Emojis.AddRange(i.Emojis.Select(x => x.ToGrpc()));
        v.Options.AddRange(i.Options.Select(x => x.ToGrpc()));

        return v;
    }

    public static Grpc.Poll.Types.Option ToGrpc(this Mastodon.Models.Poll.Option i)
    {
        var v = new Grpc.Poll.Types.Option
        {
            Title = i.Title,
        };

        if (i.VotesCount != null)
        {
            v.VotesCount = i.VotesCount.Value;
        }

        return v;
    }


    public static Data.PollKind ToData(this Grpc.PollKind i)
    {
        return i switch
        {
            Grpc.PollKind.Priority => Data.PollKind.Priority,
            Grpc.PollKind.Multiple => Data.PollKind.Multiple,
            Grpc.PollKind.Single => Data.PollKind.Single,
            Grpc.PollKind.Weighted => Data.PollKind.Weighted,
            _ => throw new NotImplementedException(),
        };
    }
}
