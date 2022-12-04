using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Language : IDocument
    {
        [JsonPropertyName("id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonPropertyName("LanguageId")]
        public int LanguageId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }


        
    }
}
