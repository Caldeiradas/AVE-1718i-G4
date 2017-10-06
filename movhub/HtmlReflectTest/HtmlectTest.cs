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
            Htmlect html = new Htmlect();
            Movie movie = movieDb.MovieDetails(860);
            html.ToHtml(movie);

        }


        [TestMethod]
        public void ToHtmlArrayTest()
        {

            
        }

    }
}
