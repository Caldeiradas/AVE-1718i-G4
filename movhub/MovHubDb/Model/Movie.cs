using System;
using HtmlReflect;
using Newtonsoft.Json;

namespace MovHubDb.Model
{
    public class Movie
    {
        [HtmlIgnore]
        public int id { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("tagline")]
        public string Tagline {get; set;}

        [HtmlAs("<li class='list-group-item'><a href='/movies/{value}/credits'>cast and crew </a></li>")]
        public string credits { get { return id.ToString(); } }
    
        [JsonProperty("budget")]
        public long Budget { get; set; }

        [HtmlIgnore]
        public double popularity { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

      
        public override string ToString() {
            return "id=" + id + "\n" +
                    "OriginalTitle=" + OriginalTitle + "\n" +
                    "credits=" + credits + "\n" +
                    "Budget=" + Budget + "\n" +
                    "popularity=" + popularity + "\n" +
                    "vote_average=" + vote_average + "\n" +
                    "release_date=" + release_date + "\n" +
                    "overview=" + overview + "\n";

        }
    }
}