using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovHubDb;
using MovHubDb.Model;
using HtmlReflect;
using System.Reflection;

namespace HtmlReflectTest
{
    class MoviesPropGetter : AbstractPropArrayGetter
    {
        public override string GetHtmlString(object obj)
        {
            string res = "";
            MovieSearchItem[] movieSearchList = (MovieSearchItem[]) obj;
            MovieSearchItem movieSearch = movieSearchList[0];
            //PropertyInfo[] props = movieSearch.GetType().GetProperties();
            //foreach (PropertyInfo p in props) {
            //    res += string.Format("PropertyHeaderName:{0}; ", p.Name);
            //}
            //foreach (MovieSearchItem ms in movieSearchList) {
            //    PropertyInfo[] msps = ms.GetType().GetProperties();
            //    foreach (PropertyInfo p in props)
            //    {
            //        res+= string.Format("Propertyvalue:{0}; ", p.GetValue(ms));
            //    }

            //}


            return null;

        }

    }
}
