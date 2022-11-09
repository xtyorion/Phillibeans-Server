using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Solutions : IDocument
    {
        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("SolutionId")]
        public int SolutionId { get; set; }

        [JsonPropertyName("Challengeid")]
        public int Challengeid { get; set; }

        [JsonPropertyName("vidSolutionURL")]
        public string? vidSolutionURL { get; set; }

        [JsonPropertyName("LangTypeId")]
        public int LangTypeId { get; set; }

        [JsonPropertyName("SolutionCode")]
        public string? SolutionCode { get; set; }

       

    }
}
