using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VinylCatalogApi.Models
{
    public class VinylRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public string Year { get; set; } = null!;
    }
}
