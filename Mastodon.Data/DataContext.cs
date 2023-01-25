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

    public async Task VoteAsync(string id, string userId)
    {
        var filter = Builders<Poll>.Filter.Eq(p => p.StatusId, id);
        {
            var update = Builders<Poll>.Update
            .SetOnInsert(p => p.StatusId, id)
            .SetOnInsert(p => p.Kind, PollKind.Weighted)
            .SetOnInsert(p => p.Votes, new Dictionary<string, Vote>
            {
                [userId] = new Vote { UserId = userId, Choices = new List<VoteChoice> { } }
            });

            var result = await Poll.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }

        {
            var update = Builders<Poll>.Update.Set(p => p.Votes[userId], new Vote { UserId = userId, Choices = new List<VoteChoice> { } });
            var result = await Poll.UpdateOneAsync(filter, update);
        }
    }

    public Task CreatePollAsync(string statusId, PollKind kind)
    {
        var poll = new Data.Poll
        {
            StatusId = statusId,
            Kind = kind,
            Votes = new Dictionary<string, Vote>(),
        };

        return Poll.InsertOneAsync(poll);
    }
}
