using HtmlReflect;

namespace MovHubDb.Model
{
    public class MovieSearchItem
    {

        [HtmlIgnore]
        public int Id { get; set; }

        public string Title { get; set; }

        public string release_date { get; set; }

        public double vote_average { get; set; }

        public override string ToString()
        {
            return "id=" + Id + "\n" +
                    "Title=" + Title + "\n" +
                    "vote_average=" + vote_average + "\n" +
                    "release_date=" + release_date + "\n";
                    

        }

    }
}