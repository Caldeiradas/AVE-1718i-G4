﻿using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MovHubDb
{
    public class TheMovieDbClient
    {

        private WebClient client = new WebClient();
        private const string uriprefix = "https://api.themoviedb.org/3/";
        private const string key = "?api_key=8d3a500e709b7e1ff4c80b09bda127c4";

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
            return movieSearch;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/860?api_key=8d3a500e709b7e1ff4c80b09bda127c4
        /// </summary>
        public Movie MovieDetails(int id) {
            string uri = uriprefix + "movie/" + id + key;
            string body = client.DownloadString(uri);
            Movie movie = (Movie)JsonConvert.DeserializeObject(body, typeof(Movie));
            return movie;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/860/credits?api_key=8d3a500e709b7e1ff4c80b09bda127c4
        /// </summary>  
        public CreditsItem[] MovieCredits(int id) {
            string uri = uriprefix + "movie/" + id + "/credits" + key;
            string body = client.DownloadString(uri);
            Credits creditsQuery = (Credits)JsonConvert.DeserializeObject(body, typeof(Credits));
            CreditsItem[] credits = creditsQuery.cast;
            //return new CreditsItem[0];
            return credits; 
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=*****
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            string uri = uriprefix + "person/" + actorId + key;
            string body = client.DownloadString(uri);
            Person person = (Person)JsonConvert.DeserializeObject(body, typeof(Person));
            return person;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=*****
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId) {
            string uri = uriprefix + "person/" + actorId + "/movie_credits"+key;
            string body = client.DownloadString(uri);
            MovieSearch movielist = (MovieSearch)JsonConvert.DeserializeObject(body, typeof(MovieSearch));
            MovieSearchItem[] movieSearch = movielist.results;
            return movieSearch;
        }
    }
}
