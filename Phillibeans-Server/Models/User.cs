﻿// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class UserRoot
    {
        [JsonPropertyName("User")]
        public User User { get; set; }
    }

    public class User : IDocument   
    {
        public static int nextId = 0;
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("userid")]
        public int UserId = nextId++;

        [JsonPropertyName("createdat")]
        public DateTime CreatedAt => Id.CreationTime;

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("passwordHash")]
        public byte[] PasswordHash { get; set; }        
        
        [JsonPropertyName("passwordSalt")]
        public byte[] PasswordSalt { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }


    }

}