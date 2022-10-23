// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class UserRoot
    {
        [JsonPropertyName("User")]
        public User User { get; set; }
    }

    public class User
    {
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("passwordHash")]
        public byte[] PasswordHash { get; set; }        
        
        [JsonPropertyName("passwordSalt")]
        public byte[] PasswordSalt { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }
    }

}