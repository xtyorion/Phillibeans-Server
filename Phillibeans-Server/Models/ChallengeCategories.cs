
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class ChallengeCategories : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

    }
}
