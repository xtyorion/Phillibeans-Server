namespace Phillibeans_Server.Models
{
    public class Solutions
    {
        public int id { get; set; }
        public int Challengeid { get; set; }
        public string vidSolutionURL { get; set; }
        public int LangTypeId { get; set; }
        public string SolutionCode { get; set; }

        static int NextId = 0;

        public Solutions()
        {
            id = NextId++;
        }

    }
}
