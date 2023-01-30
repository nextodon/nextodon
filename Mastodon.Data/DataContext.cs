using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Mastodon.Data;

public sealed class DataContext
{
    internal readonly IMongoDatabase database;
    public readonly IMongoCollection<Poll> Poll;

    private static bool inited = false;

    static DataContext()
    {
        RegisterConventions();
    }

    public static void RegisterConventions()
    {
        if (inited)
        {
            return;
        }

        var pack = new ConventionPack
            {
                new IgnoreIfNullConvention(false),
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String),
            };

        ConventionRegistry.Register("camelCase", pack, t => true);
        inited = true;
    }

    public DataContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        database = client.GetDatabase(settings.Value.Database);

        Poll = database.GetCollection<Poll>("poll");
    }

    public async Task VoteAsync(string statusId, string userId, List<VoteChoice> choices)
    {
        var filter = Builders<Poll>.Filter.Eq(p => p.StatusId, statusId);

        var update = Builders<Poll>.Update.Set(p => p.Votes[userId], new Vote { UserId = userId, Choices = choices });
        var result = await Poll.UpdateOneAsync(filter, update);
    }

    public Task CreatePollAsync(string statusId, PollKind kind, List<string> options)
    {
        var poll = new Data.Poll
        {
            StatusId = statusId,
            Kind = kind,
            Votes = new Dictionary<string, Vote>(),
            Options = options,
        };

        return Poll.InsertOneAsync(poll);
    }
}
