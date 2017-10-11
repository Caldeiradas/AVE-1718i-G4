using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb;
using MovHubDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlReflectTest
{
    [TestClass]
    class AttributesTest
    {
        private TheMovieDbClient movieDb = new TheMovieDbClient();

        /*
         * Se este parametro estiver a NULL é sinal que 
         * [JsonProperty("vote_average")]não está a funcionar 
         */
        [TestMethod]
        public void JsonAttributTest()
        {
            Movie movie = movieDb.MovieDetails(1018);
            Assert.IsNotNull(movie.VoteAverage); // origainalmente é Vote_Average em Json
        }
    }
}
    