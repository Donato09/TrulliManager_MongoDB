namespace TrulliManager.Database
{
    public interface ITrulliManagerDatabaseSettings
    {
        string TrulliCollectionName { get; set; }
        string PropertiesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
