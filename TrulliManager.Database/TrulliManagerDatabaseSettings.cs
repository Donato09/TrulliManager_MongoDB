namespace TrulliManager.Database
{
    public class TrulliManagerDatabaseSettings : ITrulliManagerDatabaseSettings
    {
        public string TrulliCollectionName { get; set; }
        public string PropertiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
