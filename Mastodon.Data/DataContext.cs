using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Mastodon.Data;

public sealed class DataContext
{
    internal readonly IMongoDatabase database;
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
    }
}
