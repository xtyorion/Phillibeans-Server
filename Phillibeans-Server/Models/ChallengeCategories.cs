namespace Phillibeans_Server.Models
{
    public class ChallengeCategories
    {
        public int id { get; set; }
        public string ChallengeName { get; set; }


        static int NextId = 0;

        public ChallengeCategories()
        {
            id = NextId++;
        }
    }
}
