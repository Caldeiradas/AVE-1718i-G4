using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb;
using MovHubDb.Model;

namespace HtmlReflectTest
{
    [TestClass]
    public class MovieHubDbTest
    {
        TheMovieDbClient movieDb = new TheMovieDbClient();
        [TestMethod]
        public void MovieSearchTest()
        {
            MovieSearchItem[] movieSearch = movieDb.Search("war games", 1);
            Assert.AreEqual(movieSearch.Length, 6);
            Assert.AreEqual(movieSearch[0].Id, 14154);  
        }

        [TestMethod]
        public void MovieDetailsTest()
        {
            Movie movie = movieDb.MovieDetails(860);
            Assert.AreEqual(movie.OriginalTitle, "WarGames");
        }

        [TestMethod]
        public void MovieCredits()
        {
            CreditsItem[] credits = movieDb.MovieCredits(860);
            Assert.AreEqual(credits[0].id, 4756);
            Assert.AreEqual(credits[0].name, "Matthew Broderick");
        }

        [TestMethod]
        public void PersonDetailsTest()
        {
            CreditsItem[] credits = movieDb.MovieCredits(860);
            Assert.AreEqual(credits[0].id, 4756);
            Assert.AreEqual(credits[0].name, "Matthew Broderick");
        }


    }
}
