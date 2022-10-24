using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Challenges : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("createdat")]
        public DateTime CreatedAt => Id.CreationTime;
        public int ChallengeId { get; set; }
        public string ChallengeCatName { get; set; }
        public int typeID { get; set; }
        public int catID { get; set; }

        static int NextId = 0;

        public Challenges()
        {
            ChallengeId = NextId++;
        }

    }
}
