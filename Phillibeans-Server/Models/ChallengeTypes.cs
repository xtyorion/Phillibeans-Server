
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class ChallengeTypes : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("ChallengeTypeId")]
        public int ChallengeTypeId { get; set; }

        [JsonPropertyName("TypeName")]
        public string TypeName { get; set; }


    }
}
