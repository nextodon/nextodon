namespace Mastodon.Services;

public sealed class InstanceService : Mastodon.Grpc.InstanceApi.InstanceApiBase {

    private readonly ILogger<InstanceService> _logger;
    private readonly Data.DataContext _db;

    public InstanceService(ILogger<InstanceService> logger, DataContext db) {
        _logger = logger;
        _db = db;
    }

    public override async Task<Grpc.Instance> GetInstance(Empty request, ServerCallContext context) {
        var instance = await _db.Instance.FirstOrDefaultAsync();

        if (instance == null) {
            instance = new Data.Instance {
                Title = "ForDem",
                Version = "4.0.2",
                Description = "ForDem Description",
                ShortDescription = "ForDem Description",
                Registrations = new Data.Instance.Types.Registrations {
                    Enabled = true,
                    ApprovalRequired = false
                },
                Configuration = new Data.Instance.Types.Configuration {
                    Accounts = new Data.Instance.Types.Configuration.Types.Accounts {
                        MaxFeaturedTags = 1000,
                    },
                    Polls = new Data.Instance.Types.Configuration.Types.Polls { },
                    Statuses = new Data.Instance.Types.Configuration.Types.Statuses { },
                    Translation = new Data.Instance.Types.Configuration.Types.Translation {
                        Enabled = false
                    },
                    Urls = new Data.Instance.Types.Configuration.Types.Urls {
                        Streaming = ""
                    },
                    MediaAttachments = new Data.Instance.Types.Configuration.Types.MediaAttachments {
                        ImageMatrixLimit = 4096 * 4096,
                        ImageSizeLimit = 50 * 1024 * 1024,
                        SupportedMimeTypes = new List<string> { },
                        VideoSizeLimit = 50 * 1024 * 1024,
                        VideoMatrixLimit = 1024 * 1024,
                        VideoFrameRateLimit = 120,
                    },

                },
                Contact = new Data.Instance.Types.Contact {
                    AccountId = "0xa98641d8031bc594ddb95f770f3101fa38c6efda",
                    Email = "admin@localhost",
                },

                Languages = new List<string> { "en" },
                Rules = new List<Data.Rule> { },
                Thumbnail = new Data.Instance.Types.Thumbnail {
                    Url = "https://fordem.org",
                },
            };


            await _db.Instance.InsertOneAsync(instance, new InsertOneOptions { }, context.CancellationToken);
        }


        var i = instance.ToGrpc();

        return i;
    }

    public override async Task<InstanceV1> GetInstanceV1(Empty request, ServerCallContext context) {
        var instance = await _db.Instance.FirstOrDefaultAsync();

        if (instance == null) {
            instance = new Data.Instance {
                Title = "ForDem",
                Version = "4.0.2",
                Description = "ForDem Description",
                ShortDescription = "ForDem Description",
                Registrations = new Data.Instance.Types.Registrations {
                    Enabled = true,
                    ApprovalRequired = false
                },
                Configuration = new Data.Instance.Types.Configuration {
                    Accounts = new Data.Instance.Types.Configuration.Types.Accounts {
                        MaxFeaturedTags = 1000,
                    },
                    Polls = new Data.Instance.Types.Configuration.Types.Polls { },
                    Statuses = new Data.Instance.Types.Configuration.Types.Statuses { },
                    Translation = new Data.Instance.Types.Configuration.Types.Translation {
                        Enabled = false
                    },
                    Urls = new Data.Instance.Types.Configuration.Types.Urls {
                        Streaming = ""
                    },
                    MediaAttachments = new Data.Instance.Types.Configuration.Types.MediaAttachments {
                        ImageMatrixLimit = 4096 * 4096,
                        ImageSizeLimit = 50 * 1024 * 1024,
                        SupportedMimeTypes = new List<string> { },
                        VideoSizeLimit = 50 * 1024 * 1024,
                        VideoMatrixLimit = 1024 * 1024,
                        VideoFrameRateLimit = 120,
                    },

                },
                Contact = new Data.Instance.Types.Contact {
                    AccountId = "0xa98641d8031bc594ddb95f770f3101fa38c6efda",
                    Email = "admin@localhost",
                },

                Languages = new List<string> { "en" },
                Rules = new List<Data.Rule> { },
                Thumbnail = new Data.Instance.Types.Thumbnail {
                    Url = "https://fordem.org",
                },
            };


            await _db.Instance.InsertOneAsync(instance, new InsertOneOptions { }, context.CancellationToken);
        }


        var i = instance.ToV1();

        return i;
    }

    public override Task<Lists> GetLists(Empty request, ServerCallContext context) {
        var lists = new Lists();

        return Task.FromResult(lists);
    }
}