using HtmlReflect;

namespace MovHubDb.Model
{
    public class CreditsItem
    {
        [HtmlAs("<td><a href='/person/{value}/movies'> {value} </a></td>")]
        public int id { get; set; }

        public string character { get; set; }

        public string name { get; set; }

        public string job { get; set; }

        public string department { get; set; }

    }
}