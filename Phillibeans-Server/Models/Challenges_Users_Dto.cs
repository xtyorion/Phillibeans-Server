using MongoDB.Bson;

namespace Phillibeans_Server.Models
{
    public class Challenges_Users_Dto
    {
        public string Id { get; set; }
        public string ChallengeId { get; set; }
        public bool Status { get; set; } = false;
    }
}
