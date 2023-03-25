namespace Nextodon.Data;

/// <summary>
/// A class representing the settings for the MongoDb server.
/// </summary>
public sealed class MongoDbSettings
{
    /// <summary>
    /// The connection string for the MongoDb server.
    /// </summary>
    public required string ConnectionString
    {
        get;
        set;
    }

    /// <summary>
    /// The name of the MongoDb database where the identity data will be stored.
    /// </summary>
    public required string Database
    {
        get;
        set;
    }
}
