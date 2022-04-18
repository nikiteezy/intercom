namespace Intercom.Data;

public class DataStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string IntercomCollectionName { get; set; } = null!;
}