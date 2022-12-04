
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class ChallengeCategories : IDocument
    {
        [JsonPropertyName("Id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Challenges")]
        public Challenges[]? Challenges { get; set; }
    }
}
