using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Language : IDocument
    {
        [JsonPropertyName("Id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("LanguageId")]
        public int LanguageId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }


        
    }
}
