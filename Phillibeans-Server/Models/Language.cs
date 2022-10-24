using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Language : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("createdat")]
        public DateTime CreatedAt => Id.CreationTime;
        public int LangId { get; set; }
        public string Name { get; set; }

        static int NextId = 0;

        public Language()
        {
            LangId = NextId++;
        }

    }
}
