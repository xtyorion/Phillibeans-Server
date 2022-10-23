namespace Phillibeans_Server.Models
{
    public class Challenges
    {
        public int id { get; set; }
        public string ChallengeCatName { get; set; }
        public int typeID { get; set; }
        public int catID { get; set; }

        static int NextId = 0;

        public Challenges()
        {
            id = NextId++;
        }

    }
}
