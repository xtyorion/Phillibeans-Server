using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Challenges : IDocument
    {
        [BsonId]
        [JsonPropertyName("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("TypeID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? typeID { get; set; }
        [JsonPropertyName("CategoryID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? categoryID { get; set; }

        [JsonPropertyName("SolutionID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? solutionID { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

    }
}
