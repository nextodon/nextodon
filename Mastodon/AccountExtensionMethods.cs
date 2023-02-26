namespace Mastodon;

public static class AccountExtensionMethods {
    public static Grpc.Accounts ToGrpc(this IEnumerable<Mastodon.Data.Account>? i) {
        var accounts = new Grpc.Accounts();
        if (i != null) {
            foreach (var r in i) {
                accounts.Data.Add(r.ToGrpc());
            }
        }

        return accounts;
    }

    public static Grpc.Account ToGrpc(this Mastodon.Data.Account i) {
        var v = new Grpc.Account {
            Id = i.Id,
            Acct = WebFingerHelper.FixAcct(i.Id),
            Avatar = "https://img.freepik.com/premium-photo/soccer-ball-colourful-background-mixed-media_641298-12866.jpg?w=1380",
            AvatarStatic = "https://img.freepik.com/premium-photo/soccer-ball-colourful-background-mixed-media_641298-12866.jpg?w=1380",
            DisplayName = i.DisplayName ?? i.Id,
            Header = "https://img.freepik.com/premium-photo/soccer-ball-colourful-background-mixed-media_641298-12866.jpg?w=1380",
            HeaderStatic = "https://img.freepik.com/premium-photo/soccer-ball-colourful-background-mixed-media_641298-12866.jpg?w=1380",
            Locked = false,
            Note = i.Id,
            Url = WebFingerHelper.FixUrl("https://img.freepik.com/premium-photo/soccer-ball-colourful-background-mixed-media_641298-12866.jpg?w=1380"),
            Username = i.Username ?? i.Id,
            Bot = false,
            Group = false,
            Limited = false,
            Suspended = false,
            //Role = i.Role?.ToGrpc(),
            //Source = i.Source?.ToGrpc(),
            //Moved = i.Moved?.ToGrpc(),
            CreatedAt = i.CreatedAt.ToGrpc(),
            LastStatusAt = i.CreatedAt.ToGrpc(),//TODO
            FollowersCount = 1100,
            FollowingCount = 20,
            StatusesCount = 20,
            Source = new Grpc.Account.Types.Source { },
            Discoverable = false,
            Role = new Role { Position = 0, }
        };

        if (i.Discoverable != null) {
            v.Discoverable = i.Discoverable.Value;
        }

        //if (i.FollowersCount != null)
        //{
        //    v.FollowersCount = i.FollowersCount.Value;
        //}

        //if (i.FollowingCount != null)
        //{
        //    v.FollowingCount = i.FollowingCount.Value;
        //}

        //if (i.StatusesCount != null)
        //{
        //    v.StatusesCount = i.StatusesCount.Value;
        //}


        v.Fields.AddRange(i.Fields.Select(x => x.ToGrpc()));
        //v.Emojis.AddRange(i.Emojis.Select(x => x.ToGrpc()));

        return v;
    }

    public static Grpc.Account.Types.Field ToGrpc(this Mastodon.Data.Account.Field i) {
        var v = new Grpc.Account.Types.Field {
            Name = i.Name,
            Value = i.Value,
        };

        if (i.VerifiedAt != null) {
            v.VerifiedAt = Timestamp.FromDateTime(i.VerifiedAt.Value.ToUniversalTime());
        }

        return v;
    }
}
