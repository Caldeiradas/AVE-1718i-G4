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
        [TestMethod]
        public void ToHtmlTest()
        {

            TheMovieDbClient movieDb = new TheMovieDbClient();
            Movie movie = movieDb.MovieDetails(860);
            Htmlect html = new Htmlect();
            String thisHtml = html.ToHtml(movie);
            Assert.IsTrue(
                thisHtml.Contains("<ul class='list-group'><li class='list-group-item'>" +
                                  "<strong>OriginalTitle</strong>:WarGames</li>"));

        }

        [TestMethod]
        public void ToHtmlArrayTest()
        {
            TheMovieDbClient movieDb = new TheMovieDbClient();
            CreditsItem[] credits = movieDb.MovieCredits(860);
            Htmlect html = new Htmlect();
            String thisHtml = html.ToHtml(credits);
            Assert.IsTrue(thisHtml.Contains("<tbody><tr><td><a href='/person/4756/movies'> 4756 </a>" +
                                            "</td><td>David Lightman</td><td>Matthew Broderick</td></tr><tr><td>"));

        }

    }
}
