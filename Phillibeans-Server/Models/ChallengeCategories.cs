using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class ChallengeCategories : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("createdat")]
        public DateTime CreatedAt => Id.CreationTime;
        public int idCat { get; set; }
        public string ChallengeName { get; set; }


        static int NextId = 0;

        public ChallengeCategories()
        {
            idCat = NextId++;
        }
    }
}
