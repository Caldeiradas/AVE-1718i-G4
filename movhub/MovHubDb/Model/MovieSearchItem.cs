using HtmlReflect;
using Newtonsoft.Json;

namespace MovHubDb.Model
{
    public class MovieSearchItem
    {

        [JsonProperty("id")]
        [HtmlAs("<td><a href='/person/{value}/movies'> {value} </a></td>")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("release_date")]
        public string release_date { get; set; }

        [JsonProperty("vote_average")]
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