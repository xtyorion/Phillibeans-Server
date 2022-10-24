using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Phillibeans_Server.Models
{
    public class Solutions : IDocument
    {

        [JsonPropertyName("id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("createdat")]
        public DateTime CreatedAt => Id.CreationTime;
        public int SolutionId { get; set; }
        public int Challengeid { get; set; }
        public string vidSolutionURL { get; set; }
        public int LangTypeId { get; set; }
        public string SolutionCode { get; set; }

        static int NextId = 0;

        public Solutions()
        {
            SolutionId = NextId++;
        }

    }
}
