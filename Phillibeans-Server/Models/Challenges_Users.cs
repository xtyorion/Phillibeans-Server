using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Challenges_Users
    {
        [JsonPropertyName("challenge_id")]
        public ObjectId Challenge_Id { get; set; }

        [JsonPropertyName("user_id")]
        public ObjectId User_Id { get; set; }

        [JsonPropertyName("status")]
        public bool Status = false;
    }
}
