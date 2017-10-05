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
        public void SearchTest()
        {
            MovieSearchItem[] movieSearch = movieDb.Search("war games", 1);
            Assert.AreEqual(movieSearch.Length, 6);
            Assert.AreEqual(movieSearch[0].Id, 14154);
        }
    }
}
