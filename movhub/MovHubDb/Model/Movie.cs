using System;
using HtmlReflect;


namespace MovHubDb.Model
{
    public class Movie
    {
        [HtmlIgnore]
        public int Id { get; set; }

        public string OriginalTitle { get; set; }

        [HtmlAs("<li class='list-group-item'><a href='/movies/{value}/credits'>cast and crew </a></li>")]
        public string Credits {
            get { return Id.ToString(); }
        }

        [HtmlIgnore]
        public long Budget { get; set; }
        public double Popularity { get; set; }

        public double Voteaverage { get; set; }

        public string Releasedate { get; set; }

        [HtmlAs("<div class='card-body bg-light'><div><strong>{name}</strong>:</div>{value}</div>")]
        public string Overview { get; set; }
    }
}