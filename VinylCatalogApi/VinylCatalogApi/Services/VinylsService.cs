using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VinylCatalogApi.Models;

namespace VinylCatalogApi.Services
{
    public class VinylsService
    {
        private readonly IMongoCollection<VinylRecord> _vinylsCollection;

        public VinylsService(
            IOptions<VinylCatalogDatabaseSettings> vinylCatalogDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                vinylCatalogDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                vinylCatalogDatabaseSettings.Value.DatabaseName);

            _vinylsCollection = mongoDatabase.GetCollection<VinylRecord>(
                vinylCatalogDatabaseSettings.Value.VinylsCollectionName);
        }

        public async Task<List<VinylRecord>> GetAsync() =>
            await _vinylsCollection.Find(_ => true).ToListAsync();

        public async Task<VinylRecord?> GetAsync(string id) =>
            await _vinylsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(VinylRecord newVinyl) =>
            await _vinylsCollection.InsertOneAsync(newVinyl);

        public async Task UpdateAsync(string id, VinylRecord updatedBook) =>
            await _vinylsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _vinylsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
