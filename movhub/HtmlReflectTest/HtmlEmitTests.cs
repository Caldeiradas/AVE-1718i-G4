using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb;
using HtmlReflect;
using MovHubDb.Model;

namespace HtmlReflectTest
{
    [TestClass]
    public class HtmlEmitTests
    {

        private TheMovieDbClient movieDb = new TheMovieDbClient();
        private HtmlEmit html = new HtmlEmit();

        [TestMethod]
        public void ToHtmlEmitTest()
        {

            Movie movie = movieDb.MovieDetails(860);
            String thisHtml = html.ToHtml(movie);

            Assert.IsTrue(
                thisHtml.Contains("<ul class='list-group'><li class='list-group-item'>" +
                                  "<strong>OriginalTitle</strong>:WarGames</li>"));
        }
    }
}
