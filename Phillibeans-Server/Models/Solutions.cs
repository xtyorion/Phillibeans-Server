using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Solutions : IDocument
    {
        [JsonPropertyName("id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonPropertyName("vidSolutionURL")]
        public string? vidSolutionURL { get; set; }

        [JsonPropertyName("LangTypeId")]
        public int LangTypeId { get; set; }

        [JsonPropertyName("SolutionCode")]
        public string? SolutionCode { get; set; }

       

    }
}
