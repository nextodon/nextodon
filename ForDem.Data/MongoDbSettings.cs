namespace ForDem.Data;

public sealed class MongoDbSettings
{
    public string ConnectionString { get; set; } = default!;

    public string DatabaseName { get; set; } = default!;
}
