using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Challenges_Users
    {
        [JsonPropertyName("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("Challenge_Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Challenge_Id { get; set; }

        [JsonPropertyName("User_Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string User_Id { get; set; }

        [JsonPropertyName("Status")]
        public bool Status {get; set;}
    }
}
