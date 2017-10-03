﻿using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MovHubDb
{
    public class TheMovieDbClient
    {

        WebClient client = new WebClient();
        string uriprefix = "https://api.themoviedb.org/3/";
        string key = "?api_key=8d3a500e709b7e1ff4c80b09bda127c4";

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/search/movie?api_key=8d3a500e709b7e1ff4c80b09bda127c4&query=war%20games
        /// </summary>
        public MovieSearchItem[] Search(string title, int page)
        {

            title = title.Trim().Replace(" ", "+");
            string uri = uriprefix + "search/movie" + key + "&query=" + title;
            string body = client.DownloadString(uri);
            MovieSearch movielist = (MovieSearch)JsonConvert.DeserializeObject(body, typeof(MovieSearch));
            MovieSearchItem[] movieSearch = movielist.results;
            //return new MovieSearchItem[0];
            return movieSearch;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508?api_key=8d3a500e709b7e1ff4c80b09bda127c4
        /// </summary>
        public Movie MovieDetails(int id) {
            return new Movie();
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508/credits?api_key=*****
        /// </summary>
        public CreditsItem[] MovieCredits(int id) {
            return new CreditsItem[0];
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=*****
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            return new Person();
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=*****
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId) {
            return new MovieSearchItem[0];
        }
    }
}
