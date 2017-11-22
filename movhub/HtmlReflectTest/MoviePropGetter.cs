using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovHubDb;
using MovHubDb.Model;

namespace HtmlReflect
{
    class MoviePropGetter : AbstractPropGetter
    {
        public override string GetHtmlString(object obj)
        {
            string res = "";
            Movie  m = (Movie)obj;
            string originalTitleValue = m.OriginalTitle;
            res += FormatNotIgnoreToHtml("originalTitle", originalTitleValue);
            string v = m.Budget.ToString();
           // string attrValue = "<li class='list-group-item'><a href='/movies/{value}/credits'>cast and crew </a></li>";

            return res;

        }

    }


    
}
