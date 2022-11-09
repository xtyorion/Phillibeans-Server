
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class ChallengeCategories : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("ChallengeCatId")]
        public int ChallengeCatId { get; set; }

        [JsonPropertyName("ChallengeName")]
        public string ChallengeName { get; set; }

    }
}
