
using MongoDB.Bson;

namespace Phillibeans_Server.Models
{
    public class ChallengeDto
    {
        public string Name { get; set; } = string.Empty;
        public string typeID { get; set; } = string.Empty;
        public string categoryID { get; set; } = string.Empty;
    }
}
