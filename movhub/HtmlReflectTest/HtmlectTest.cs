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

        // Utilizou-se para este teste o id 15008 pois pertence a um actriz ja falecido
        // assim sendo o dados de teste são imutaveis
        [TestMethod]
        public void ToHtmlArrayTest()
        {
            MovieSearchItem[] personCredits = movieDb.PersonMovies(15008);
            String thisHtml = html.ToHtml(personCredits);
            Assert.IsTrue(thisHtml.Contains("<tr><td><a href='/person/1018/movies'> 1018 </a></td><td>Mulholland Drive</td>"));

        }

    }
}
