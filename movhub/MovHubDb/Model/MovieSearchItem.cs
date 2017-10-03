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

    }
}