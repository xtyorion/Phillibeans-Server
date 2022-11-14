using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Challenges : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("ChallengeId")]
        public int ChallengeId { get; set; }


        [JsonPropertyName("idChallengeCatName")]
        public string ChallengeCatName { get; set; }

        [JsonPropertyName("typeID")]
        public int typeID { get; set; }

        [JsonPropertyName("catID")]
        public int catID { get; set; }

        [JsonPropertyName("Completed")]
        public bool Completed { get; set; }
    }
}
