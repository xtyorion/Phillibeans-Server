using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class ChallengeTypes : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("createdat")]
        public DateTime CreatedAt => Id.CreationTime;
        public int ChallengeTypeId { get; set; }
        public string TypeName { get; set; }

        static int NextId = 0;

        public ChallengeTypes()
        {
            ChallengeTypeId = NextId++;
        }

    }
}
