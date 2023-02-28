namespace Mastodon;

public static class InstanceExtensionMethods {
    //public static Grpc.Activities ToGrpc(this IEnumerable<Mastodon.Models.Activity>? i) {
    //    var rules = new Grpc.Activities();

    //    if (i != null) {
    //        foreach (var r in i) {
    //            rules.Data.Add(r.ToGrpc());
    //        }
    //    }

    //    return rules;
    //}

    public static Grpc.Instance ToGrpc(this Mastodon.Data.Instance i) {
        var v = new Grpc.Instance {
            Domain = "fordem.org",
            Title = i.Title,
            Version = i.Version,
            SourceUrl = "",
            Description = i.Description,
            Usage = new Grpc.Instance.Types.Usage { Users = new Grpc.Instance.Types.Usage.Types.Users { ActiveMonth = 1000 } },
            Thumbnail = i.Thumbnail.ToGrpc(),
            Configuration = i.Configuration.ToGrpc(),
            Registrations = i.Registrations.ToGrpc(),
            Contact = i.Contact.ToGrpc(),
        };

        v.Languages.AddRange(i.Languages);
        v.Rules.AddRange(i.Rules.Select(x => x.ToGrpc()));

        return v;
    }

    public static Grpc.InstanceV1 ToV1(this Mastodon.Data.Instance i) {
        var v = new InstanceV1 {
            Uri = "fordem.org",
            Title = i.Title,
            Email = i.Contact.Email,
            Description = i.Description,
            ShortDescription = i.ShortDescription,
            Version = i.Version,
            ApprovalRequired = i.Registrations.ApprovalRequired,
            Urls = new InstanceV1.Types.Urls { StreamingApi = i.Configuration.Urls.Streaming },
            Thumbnail = i.Thumbnail.Url,
            Stats = new InstanceV1.Types.Stats { },
        };

        v.Languages.Add(i.Languages);

        return v;
    }

    //public static Grpc.InstanceV1 ToGrpc(this Mastodon.Data.InstanceV1 i) {
    //    var v = new Grpc.InstanceV1 {
    //        Uri = i.Uri,
    //        Title = i.Title,
    //        Version = i.Version,
    //        ApprovalRequired = i.ApprovalRequired,
    //        Email = i.Email,
    //        InvitesEnabled = i.InvitesEnabled,
    //        ShortDescription = i.ShortDescription,
    //        Stats = new InstanceV1.Types.Stats {
    //            DomainCount = i.Stats.DomainCount,
    //            StatusCount = i.Stats.StatusCount,
    //            UserCount = i.Stats.UserCount,
    //        },
    //        Description = i.Description,
    //        Thumbnail = i.Thumbnail,
    //        Configuration = new InstanceV1.Types.Configuration {
    //            Accounts = i.Configuration.Accounts.ToGrpc(),
    //            MediaAttachments = i.Configuration.MediaAttachments?.ToGrpc(),
    //            Polls = i.Configuration.Polls?.ToGrpc(),
    //            Statuses = i.Configuration.Statuses?.ToGrpc(),
    //        },
    //        Registrations = i.Registrations,
    //        ContactAccount = i.ContactAccount.ToGrpc(),
    //        Urls = new InstanceV1.Types.Urls {
    //            StreamingApi = i.Urls.StreamingApi
    //        },
    //    };

    //    v.Languages.AddRange(i.Languages);
    //    v.Rules.AddRange(i.Rules.Select(x => x.ToGrpc()));

    //    return v;
    //}

    //public static Grpc.Activity ToGrpc(this Mastodon.Data.Activity i) {
    //    return new Activity {
    //        Logins = i.Logins,
    //        Registrations = i.Registrations,
    //        Statuses = i.Statuses,
    //        Week = i.Week,
    //    };
    //}

    public static Grpc.Instance.Types.Contact ToGrpc(this Mastodon.Data.Instance.Types.Contact i) {
        return new Grpc.Instance.Types.Contact {
            Email = i.Email,
            //Account = i.Account.ToGrpc(),
        };
    }

    public static Grpc.Instance.Types.Registrations ToGrpc(this Mastodon.Data.Instance.Types.Registrations i) {
        return new Grpc.Instance.Types.Registrations {
            Enabled = i.Enabled,
            ApprovalRequired = i.ApprovalRequired,
            Message = i.Message ?? string.Empty,
        };
    }

    public static Grpc.Instance.Types.Configuration ToGrpc(this Mastodon.Data.Instance.Types.Configuration i) {
        return new Grpc.Instance.Types.Configuration {
            Accounts = i.Accounts.ToGrpc(),
            MediaAttachments = i.MediaAttachments?.ToGrpc(),
            Polls = i.Polls.ToGrpc(),
            Statuses = i.Statuses.ToGrpc(),
            Translation = i.Translation.ToGrpc(),
            Urls = i.Urls.ToGrpc(),
        };
    }

    public static Grpc.Instance.Types.Configuration.Types.Accounts ToGrpc(this Mastodon.Data.Instance.Types.Configuration.Types.Accounts i) {
        return new Grpc.Instance.Types.Configuration.Types.Accounts {
            MaxFeaturedTags = i.MaxFeaturedTags ?? 0,
        };
    }

    public static Grpc.Instance.Types.Configuration.Types.MediaAttachments ToGrpc(this Mastodon.Data.Instance.Types.Configuration.Types.MediaAttachments i) {
        var v = new Grpc.Instance.Types.Configuration.Types.MediaAttachments {
            ImageMatrixLimit = i.ImageMatrixLimit,
            ImageSizeLimit = i.ImageSizeLimit,
            VideoFrameRateLimit = i.VideoFrameRateLimit,
            VideoMatrixLimit = i.VideoMatrixLimit,
            VideoSizeLimit = i.VideoSizeLimit,
        };

        v.SupportedMimeTypes.AddRange(i.SupportedMimeTypes);

        return v;
    }

    public static Grpc.Instance.Types.Configuration.Types.Polls ToGrpc(this Mastodon.Data.Instance.Types.Configuration.Types.Polls i) {
        return new Grpc.Instance.Types.Configuration.Types.Polls {
            MaxCharactersPerOption = i.MaxCharactersPerOption ?? 0,
            MaxOptions = i.MaxOptions ?? 0,
            MinExpiration = i.MinExpiration ?? 0,
            MaxExpiration = i.MaxExpiration ?? 0,
        };
    }

    public static Grpc.Instance.Types.Configuration.Types.Statuses ToGrpc(this Mastodon.Data.Instance.Types.Configuration.Types.Statuses i) {
        return new Grpc.Instance.Types.Configuration.Types.Statuses {
            CharactersReservedPerUrl = i.CharactersReservedPerUrl ?? 0,
            MaxCharacters = i.MaxCharacters ?? 0,
            MaxMediaAttachments = i.MaxMediaAttachments ?? 0,
        };
    }

    public static Grpc.Instance.Types.Configuration.Types.Translation ToGrpc(this Mastodon.Data.Instance.Types.Configuration.Types.Translation i) {
        return new Grpc.Instance.Types.Configuration.Types.Translation {
            Enabled = i.Enabled,
        };
    }

    public static Grpc.Instance.Types.Configuration.Types.Urls ToGrpc(this Mastodon.Data.Instance.Types.Configuration.Types.Urls i) {
        return new Grpc.Instance.Types.Configuration.Types.Urls {
            Streaming = i.Streaming,
        };
    }

    //public static Grpc.Instance.Types.Usage ToGrpc(this Mastodon.Data.Instance.Usage i) {
    //    return new Grpc.Instance.Types.Usage {
    //        Users = new Instance.Types.Usage.Types.Users {
    //            ActiveMonth = i.Users.ActiveMonth,
    //        }
    //    };
    //}

    public static Grpc.Instance.Types.Thumbnail ToGrpc(this Mastodon.Data.Instance.Types.Thumbnail i) {
        var v = new Grpc.Instance.Types.Thumbnail {
            Url = i.Url,
            Versions = i.Versions?.ToGrpc(),
        };

        if (i.Blurhash != null) {
            v.Blurhash = i.Blurhash;
        }

        return v;
    }

    public static Grpc.Instance.Types.Thumbnail.Types.Versions ToGrpc(this Mastodon.Data.Instance.Types.Thumbnail.Types.Versions i) {
        return new Grpc.Instance.Types.Thumbnail.Types.Versions {
            OneX = i.OneX,
            TwoX = i.TwoX,
        };
    }
}
