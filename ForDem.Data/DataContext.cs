using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ForDem.Data;

public class DataContext
{
    internal readonly IMongoDatabase database;
    private static bool initialized = false;

    static DataContext()
    {
        RegisterConventions();
    }

    private static void RegisterConventions()
    {
        if (initialized)
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
        initialized = true;
    }

    public DataContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        database = client.GetDatabase(databaseName);
    }
}
