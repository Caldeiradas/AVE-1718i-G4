using HtmlReflect;
namespace MovHubDb.Model
{
    public class Person
    {
        public string birthday { get; set; }
        public string name { get; set; }
        public string imdb_id { get; set; }
    }

    public class Date
    {
        private int Year;
        private int Month;
        private int Day;
    }
}
