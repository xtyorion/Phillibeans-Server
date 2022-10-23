namespace Phillibeans_Server.Models
{
    public class Language
    {
        public int id { get; set; }
        public string Name { get; set; }

        static int NextId = 0;

        public Language()
        {
            id = NextId++;
        }

    }
}
