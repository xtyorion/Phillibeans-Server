using MongoDB.Bson;

namespace Phillibeans_Server.Models
{
    public class Challenges_Users_Dto
    {
        public string _id { get; set; }
        public string User_Id { get; set; }
        public string Challenge_Id { get; set; }
        public bool Status { get; set; } = false;
    }
}
