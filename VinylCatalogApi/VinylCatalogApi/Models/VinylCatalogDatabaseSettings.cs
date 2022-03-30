namespace VinylCatalogApi.Models
{
    public class VinylCatalogDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string VinylsCollectionName { get; set; } = null!;
    }
}
