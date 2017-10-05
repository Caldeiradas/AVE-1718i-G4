using System;
using HtmlReflect;


namespace MovHubDb.Model
{
    public class Movie
    {
        [HtmlIgnore]
        public int id { get; set; }

        public string original_title { get; set; }

        [HtmlAs("<li class='list-group-item'><a href='/movies/{value}/credits'>cast and crew </a></li>")]
        public string credits { get { return id.ToString(); } }

        [HtmlIgnore]
        public long budget { get; set; }
        public double popularity { get; set; }

        public double vote_average { get; set; }

        public string release_date { get; set; }

        [HtmlAs("<div class='card-body bg-light'><div><strong>{name}</strong>:</div>{value}</div>")]
        public string overview { get; set; }
    }
}