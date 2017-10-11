using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb;
using HtmlReflect;
using MovHubDb.Model;

namespace HtmlReflectTest
{
    [TestClass]
    public class HtmlectTest
    {
        private TheMovieDbClient movieDb = new TheMovieDbClient();
        private Htmlect html = new Htmlect();

        [TestMethod]
        public void ToHtmlTest()
        {
            Movie movie = movieDb.MovieDetails(860);
            String thisHtml = html.ToHtml(movie);

            Assert.IsTrue(
                thisHtml.Contains("<ul class='list-group'><li class='list-group-item'>" +
                                  "<strong>OriginalTitle</strong>:WarGames</li>"));

        }

        [TestMethod]
        public void ToHtmlCacheTest()
        {
            Movie movie = movieDb.MovieDetails(860);
            String thisHtml = html.ToHtml(movie);
            Movie movie2 = movieDb.MovieDetails(860);
            String thisHtml2 = html.ToHtml(movie);

            Assert.IsTrue(
                thisHtml2.Contains("<ul class='list-group'><li class='list-group-item'>" +
                                  "<strong>OriginalTitle</strong>:WarGames</li>"));

        }


        // Utilizou-se para este teste o id 15008 pois pertence a um actriz ja falecido
        // assim sendo o dados de teste são imutaveis
        [TestMethod]
        public void ToHtmlArrayTest()
        {
            MovieSearchItem[] personCredits = movieDb.PersonMovies(15008);
            String thisHtml = html.ToHtml(personCredits);
            Assert.IsTrue(thisHtml.Contains("</td><td>Mulholland Drive</td><td>2001-05-16</td><td>7,7</td></tr>"));

        }

        [TestMethod]
        public void ToHtmlArrayCacheTest()
        {
            MovieSearchItem[] personCredits = movieDb.PersonMovies(15008);
            String thisHtml = html.ToHtml(personCredits);
            MovieSearchItem[] personCredits2 = movieDb.PersonMovies(15008);
            String thisHtml2 = html.ToHtml(personCredits);

            Assert.IsTrue(thisHtml2.Contains("</td><td>Mulholland Drive</td><td>2001-05-16</td><td>7,7</td></tr>"));

        }

    }
}
