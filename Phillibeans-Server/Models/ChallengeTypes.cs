namespace Phillibeans_Server.Models
{
    public class ChallengeTypes
    {
        public int id { get; set; }
        public string TypeName { get; set; }

        static int NextId = 0;

        public ChallengeTypes()
        {
            id = NextId++;
        }

    }
}
