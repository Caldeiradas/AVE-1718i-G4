using HtmlReflect;
using Newtonsoft.Json;

namespace MovHubDb.Model
{
    public class Person
    {
        [HtmlIgnore]
        public int id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("deathday")]
        public string deathday { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("place_of_birth")]
        public string PlaceOfBirth { get; set; }

        public string profile_path { get; set; }

        public string imdb_id { get; set; }


    }
}
